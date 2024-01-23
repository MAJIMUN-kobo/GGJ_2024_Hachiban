using UnityEngine.InputSystem;
using UnityEngine;

// プレイヤークラス
public class Player : MonoBehaviour
{
	// 入力
	PlayerInput input;

	// 移動速度
	[SerializeField]
	float speed;

	// 移動値
	Vector3 movevalue = Vector3.zero;

	// 物理
	Rigidbody rb;

	private void Awake()
	{
		// 物理取得
		rb = GetComponent<Rigidbody>();

		// 入力システム生成
		input = new PlayerInput();
		// 入力システム有効化
		input.Enable();

		// 入力のコールバック登録
		input.Move.Move.performed += Move;
		input.Move.Move.canceled += Stop;
	}

	private void OnEnable()
	{
		input?.Enable();
	}

	private void OnDisable()
	{
		input?.Disable();
	}

	private void FixedUpdate()
	{
		// 移動
		rb.velocity = new Vector3(movevalue.x, rb.velocity.y, movevalue.z);
	}

	/// <summary>
	/// 移動
	/// </summary>
	/// <param name="context">入力情報</param>
	public void Move(InputAction.CallbackContext context)
	{
		// 移動する方向
		var vel = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
		// 移動値の計算
		movevalue = vel.normalized * speed;
	}

	/// <summary>
	/// 止める
	/// </summary>
	/// <param name="context"></param>
	public void Stop(InputAction.CallbackContext context)
	{
		movevalue = Vector3.zero;
	}
}