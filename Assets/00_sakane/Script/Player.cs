using UnityEngine.InputSystem;
using UnityEngine;

// プレイヤークラス
public class Player : MonoBehaviour
{
	// 入力
	PlayerInput input;

	// 移動速度
	[SerializeField]
	float moveSpeed;
	// カメラの速度
	[SerializeField]
	Vector2 cameraSpeed;
	// 可動域
	[SerializeField]
	float rangeOfMotion = 40;

	// 移動値
	Vector3 inputValue = Vector3.zero;

	// 物理
	Rigidbody rb;

	// プレイヤーのカメラ
	GameObject playerCamera;

	private void Awake()
	{
		// 物理取得
		rb = transform.GetComponent<Rigidbody>();

		// 入力システム生成
		input = new PlayerInput();
		// 入力システム有効化
		input.Enable();

		// 入力のコールバック登録
		input.Move.Move.performed += Move;
		input.Move.Move.canceled += Stop;

		input.Move.CameraMove.performed += CameraMove;

		playerCamera = Camera.main.gameObject;
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
		// 前方の移動
		var forward = transform.forward * inputValue.y;
		// 横の移動
		var right = transform.right * inputValue.x;
		// 合計の移動
		var vel = forward + right;
		// 移動値の計算
		var moveVal = vel.normalized * moveSpeed;
		// 移動
		rb.velocity = new Vector3(moveVal.x, rb.velocity.y, moveVal.z);
	}

	/// <summary>
	/// 移動
	/// </summary>
	/// <param name="context">入力情報</param>
	public void Move(InputAction.CallbackContext context)
	{
		inputValue = context.ReadValue<Vector2>();
	}

	/// <summary>
	/// 止める
	/// </summary>
	/// <param name="context"></param>
	public void Stop(InputAction.CallbackContext context)
	{
		inputValue = Vector3.zero;
	}

	/// <summary>
	/// カメラ移動
	/// </summary>
	/// <param name="context">入力情報</param>
	public void CameraMove(InputAction.CallbackContext context)
	{
		// 情報取得
		Vector3 value = context.ReadValue<Vector2>() * cameraSpeed;
		// 回転
		transform.eulerAngles += new Vector3(0, value.x, 0);

		var angle = playerCamera.transform.localEulerAngles + new Vector3(-value.y, 0, 0);

		if (!((angle.x > rangeOfMotion) &&
			(360 - rangeOfMotion > angle.x)))
		{
			// カメラの上下回転
			playerCamera.transform.localEulerAngles += new Vector3(-value.y, 0, 0);
		}
	}
}