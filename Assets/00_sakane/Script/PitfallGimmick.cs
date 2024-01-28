using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class PitfallGimmick : GimmickBehaviour
{
	[SerializeField]
	GameObject panel1;

	[SerializeField]
	GameObject panel2;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			OnTriggerActivation(other.gameObject);
		}
	}

	public override void OnTriggerActivation(GameObject target)
	{
		var token = this.GetCancellationTokenOnDestroy();

		Fall(token).Forget();
	}

	/// <summary>
	/// —Ž‚Æ‚·
	/// </summary>
	async UniTask Fall(CancellationToken token)
	{
		var angle = 0.0f;
		while (true)
		{
			panel1.transform.localEulerAngles = new Vector3(0, 0, angle);
		}
	}
}
