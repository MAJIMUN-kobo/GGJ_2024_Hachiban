using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader Instance { get; private set; }

	// true = レベル読み込み中
	static bool isLevelLoading = false;
	public static bool IsLevelLoading
	{
		get => isLevelLoading;
	}

	// true = レベルを移動することができる
	static public bool canLevelMove = true;

	// 読み込み中に表示するオブジェクト
	[SerializeField]
	GameObject loadingObject;

	private void Awake()
	{
		Instance = this;
	}

	/// <summary>
	/// シーン読み込み
	/// </summary>
	/// <param name="sceneName"></param>
	public async UniTask LoadScene(string sceneName)
	{
		// ロード中を表示
		loadingObject?.SetActive(true);
		// シーンを移動しないようにする
		canLevelMove = false;
		// 読み込み開始
		OpenScene(sceneName).Forget();
		// 読み込みが終了するまで待つ
		await UniTask.WaitUntil(() => { return IsLevelLoading; });
		// シーン移動を可能にする
		canLevelMove = true;
	}

	/// <summary>
	/// シーン切り替え
	/// </summary>
	/// <param name="levelName">シーン名</param>
	/// <returns></returns>
	public static async UniTaskVoid OpenScene(string levelName)
	{
		// 読み込み中にする
		isLevelLoading = true;
		// 読み込み
		var operation = SceneManager.LoadSceneAsync(levelName);
		// 移動できない状態にする
		operation.allowSceneActivation = false;
		// 読み込みが終了するまで待つ
		await UniTask.WaitUntil(() => operation.progress >= 0.9f);
		// 読み込み中を解除
		isLevelLoading = false;
		// 移動できる状態になるまで待つ
		await UniTask.WaitUntil(() => canLevelMove);
		// 移動できる状態にする
		operation.allowSceneActivation = true;
	}

	/// <summary>
	/// ゲーム終了
	/// </summary>
	static public void GameQuit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}

	private void OnDestroy()
	{
		Instance = null;
	}
}