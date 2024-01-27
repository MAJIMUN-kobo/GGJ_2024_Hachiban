using UnityEngine;
using Cysharp.Threading.Tasks;

public class LargeAmountGimmick : GimmickBehaviour
{
	// �v���n�u
	[SerializeField]
	GameObject spawnPrefab;

	// ������
	[SerializeField]
	int instanceValue = 1000;
	// �C���^�[�o��
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
	/// ����
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