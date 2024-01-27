using UnityEngine;

public class HumanDownGimmick : GimmickBehaviour
{
	// アニメーション
	Animator animator;
	// 物理
	Rigidbody rb;
	// true = 走っている
	bool isRunning = false;
	// 速度
	[SerializeField]
	float speed;

	[SerializeField]
	float adjustment;

	private void Awake()
	{
		// アニメーション取得
		animator = GetComponent<Animator>();
		// 物理取得
		rb = GetComponent<Rigidbody>();

#if UNITY_EDITOR

		Run();

#endif
	}

	private void FixedUpdate()
	{
		if (isRunning)
		{
			// 移動
			rb.velocity = transform.forward * speed;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		// フロア、プレイヤー、以外で、走っている状態だったら衝突
		if (!collision.gameObject.CompareTag("Floor") &&
			!collision.gameObject.CompareTag("Player") &&
			isRunning)
		{
			transform.position += transform.forward * adjustment;
			transform.localEulerAngles += new Vector3(0, 180, 0);
			// アニメーション再生
			animator.SetTrigger("Down");
			// 動きを止める
			rb.velocity = Vector3.zero;
			// 重力無効
			rb.useGravity = false;
			// 物理無効
			rb.isKinematic = true;
			// コライダー無効
			GetComponent<Collider>().enabled = false;
		}
	}

	/// <summary>
	/// 走る
	/// </summary>
	void Run()
	{
		// 走るアニメーション
		animator.SetTrigger("Run");

		isRunning = true;
	}
}