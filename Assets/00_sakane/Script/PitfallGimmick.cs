using UnityEngine;

public class PitfallGimmick : GimmickBehaviour
{
	// ��
	[SerializeField]
	GameObject floor;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			OnTriggerActivation(other.gameObject);
		}
	}

	public override void OnTriggerActivation(GameObject target)
	{
		floor.SetActive(false);
	}
}
