using UnityEngine;
using Cysharp.Threading.Tasks;

public class LargeAmountGimmick : GimmickBehaviour
{
	// プレハブ
	[SerializeField]
	GameObject spawnPrefab;

	// 生成数
	[SerializeField]
	int instanceValue = 1000;
	// インターバル
	[SerializeField]
	float interval;

	private void Start()
	{
#if UNITY_EDITOR
		Spawn().Forget();
#endif
	}

	public override void OnInputActivation(GameObject target)
	{
		Spawn().Forget();
	}

	/// <summary>
	/// 生成
	/// </summary>
	async UniTask Spawn()
	{
		var token = this.GetCancellationTokenOnDestroy();
		for (int i = 0; i < instanceValue; ++i)
		{
			Instantiate(spawnPrefab, transform.position, Quaternion.identity);

			await UniTask.WaitForSeconds(interval, cancellationToken: token);
		}
	}
}