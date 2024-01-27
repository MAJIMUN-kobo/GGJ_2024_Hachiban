using UnityEngine;

public class PlayerFall : MonoBehaviour
{
	Vector3 startPos;

	private void Awake()
	{
		startPos = transform.position;
	}

	private void Update()
	{
		if (startPos.y - 100 >= transform.position.y)
		{
			transform.position = startPos;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}
