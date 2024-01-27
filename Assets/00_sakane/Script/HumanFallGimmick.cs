using UnityEngine;
using Cysharp.Threading.Tasks;

// 転ぶ人のギミック
public class HumanFallGimmick : GimmickBehaviour
{
	// 移動速度
	[SerializeField]
	float movespeed;

	// 物理
	Rigidbody rb;

	// 転ぶまでの時間
	[SerializeField]
	float fallTime;

	// アニメーター
	Animator animator;

	// ターゲット（プレイヤー）
	GameObject target;

	// ターゲットが見える最大距離
	[SerializeField]
	float distance;

	// ターゲットが見える角度
	[SerializeField]
	float angle;

	// true = 追いかけている
	bool isChasing = false;

	// true = 止まる
	bool isStop = false;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();

		animator = GetComponent<Animator>();

#if UNITY_EDITOR
		// デバッグ用
		{
			target = GameObject.Find("Player");
			OnLookAtActivation(target);
		}
#endif
	}

	private void Update()
	{
		// 追いかけている時にターゲットが視界にいるか確認
		if (isChasing && !isStop)
		{
			if (!IsVisibilityTarget())
			{
				// 視界から外れたら転ぶ
				StopRunning().Forget();
				isStop = true;
			}
		}
	}

	public override void OnLookAtActivation(GameObject target)
	{
		// 方向
		var direction = target.transform.position - transform.position;
		// 移動
		rb.velocity = direction * movespeed;
		// 追いかけ始める
		isChasing = true;
		// ターゲット設定
		this.target = target;
		animator.SetTrigger("Start");
	}

	/// <summary>
	/// 転ぶ
	/// </summary>
	/// <returns></returns>
	async UniTask StopRunning()
	{
		// トークン取得
		var token = this.GetCancellationTokenOnDestroy();
		// 少し待つ
		await UniTask.WaitForSeconds(fallTime, cancellationToken: token);
		// アニメーション再生
		animator.SetTrigger("Fall");

		rb.isKinematic = true;
		rb.useGravity = false;
		GetComponent<Collider>().enabled = false;
	}

	/// <summary>
	/// 視界にターゲットがいるか調べる
	/// </summary>
	/// <returns>true = ターゲット</returns>
	public bool IsVisibilityTarget()
	{
		// 自身の位置
		var selfPos = transform.position;
		// ターゲットの位置
		var targetPos = target.transform.position;

		// 自身の向き（正規化されたベクトル）
		var selfDir = transform.forward;

		// ターゲットまでの向きと距離計算
		var targetDir = targetPos - selfPos;
		var targetDistance = targetDir.magnitude;

		// cos(θ/2)を計算
		var cosHalf = Mathf.Cos(angle / 2 * Mathf.Deg2Rad);

		// 自身とターゲットへの向きの内積計算
		// ターゲットへの向きベクトルを正規化する必要があることに注意
		var innerProduct = Vector3.Dot(selfDir, targetDir.normalized);

		// 視界判定
		return innerProduct > cosHalf && targetDistance < distance;
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Player"))
		{
			OnTriggerActivation(collision.gameObject);
		}
	}
}