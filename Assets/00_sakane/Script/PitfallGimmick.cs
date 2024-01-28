using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class PitfallGimmick : GimmickBehaviour
{
	[SerializeField]
	GameObject panel1;

	[SerializeField]
	GameObject panel2;
	[SerializeField]
	float speed;

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
		var t = 0.0f;
		while (true)
		{
			t += speed;
			var angle = Mathf.Lerp(0, 90f, t);
			panel1.transform.localEulerAngles = new Vector3(0, 0, -angle);
			panel2.transform.localEulerAngles = new Vector3(0, 0, angle);

			await UniTask.DelayFrame(1, cancellationToken: token);
		}
	}
}
