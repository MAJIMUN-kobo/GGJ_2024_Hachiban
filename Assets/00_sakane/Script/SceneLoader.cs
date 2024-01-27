using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader Instance { get; private set; }

	// true = ���x���ǂݍ��ݒ�
	static bool isLevelLoading = false;
	public static bool IsLevelLoading
	{
		get => isLevelLoading;
	}

	// true = ���x�����ړ����邱�Ƃ��ł���
	static public bool canLevelMove = true;

	private void Awake()
	{
		Instance = this;
	}

	/// <summary>
	/// �V�[���ǂݍ���
	/// </summary>
	/// <param name="sceneName"></param>
	public async UniTask LoadScene(string sceneName)
	{
		var token = this.GetCancellationTokenOnDestroy();

		// �V�[�����ړ����Ȃ��悤�ɂ���
		canLevelMove = false;
		// �ǂݍ��݊J�n
		OpenScene(sceneName, token).Forget();
		// �ǂݍ��݂��I������܂ő҂�
		await UniTask.WaitUntil(() => { return IsLevelLoading; }, cancellationToken: token);
		// �V�[���ړ����\�ɂ���
		canLevelMove = true;
	}

	/// <summary>
	/// �V�[���؂�ւ�
	/// </summary>
	/// <param name="levelName">�V�[����</param>
	/// <returns></returns>
	public static async UniTaskVoid OpenScene(string levelName, CancellationToken token)
	{
		// �ǂݍ��ݒ��ɂ���
		isLevelLoading = true;
		// �ǂݍ���
		var operation = SceneManager.LoadSceneAsync(levelName);
		// �ړ��ł��Ȃ���Ԃɂ���
		operation.allowSceneActivation = false;
		// �ǂݍ��݂��I������܂ő҂�
		await UniTask.WaitUntil(() => operation.progress >= 0.9f, cancellationToken: token);
		// �ǂݍ��ݒ�������
		isLevelLoading = false;
		// �ړ��ł����ԂɂȂ�܂ő҂�
		await UniTask.WaitUntil(() => canLevelMove, cancellationToken: token);
		// �ړ��ł����Ԃɂ���
		operation.allowSceneActivation = true;
	}

	/// <summary>
	/// �Q�[���I��
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