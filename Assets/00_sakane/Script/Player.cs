using UnityEngine.InputSystem;
using UnityEngine;

// �v���C���[�N���X
public class Player : MonoBehaviour
{
	// ����
	PlayerInput input;

	// �ړ����x
	[SerializeField]
	float moveSpeed;
	// �J�����̑��x
	[SerializeField]
	Vector2 cameraSpeed;
	// ����
	[SerializeField]
	float rangeOfMotion = 40;


	// �ړ��l
	Vector3 movevalue = Vector3.zero;

	// ����
	Rigidbody rb;

	// �v���C���[�̃J����
	GameObject playerCamera;

	private void Awake()
	{
		// �����擾
		rb = transform.GetComponent<Rigidbody>();

		// ���̓V�X�e������
		input = new PlayerInput();
		// ���̓V�X�e���L����
		input.Enable();

		// ���͂̃R�[���o�b�N�o�^
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
		// �ړ�
		rb.velocity = new Vector3(movevalue.x, rb.velocity.y, movevalue.z);
	}

	/// <summary>
	/// �ړ�
	/// </summary>
	/// <param name="context">���͏��</param>
	public void Move(InputAction.CallbackContext context)
	{
		// �O���̈ړ�
		var forward = transform.forward * context.ReadValue<Vector2>().y;
		// ���̈ړ�
		var right = transform.right * context.ReadValue<Vector2>().x;
		// ���v�̈ړ�
		var vel = forward + right;
		// �ړ��l�̌v�Z
		movevalue = vel.normalized * moveSpeed;
	}

	/// <summary>
	/// �~�߂�
	/// </summary>
	/// <param name="context"></param>
	public void Stop(InputAction.CallbackContext context)
	{
		movevalue = Vector3.zero;
	}

	/// <summary>
	/// �J�����ړ�
	/// </summary>
	/// <param name="context">���͏��</param>
	public void CameraMove(InputAction.CallbackContext context)
	{
		// ���擾
		Vector3 value = context.ReadValue<Vector2>() * cameraSpeed;
		// ��]
		transform.eulerAngles += new Vector3(0, value.x, 0);

		var angle = playerCamera.transform.localEulerAngles + new Vector3(-value.y, 0, 0);

		if (!((angle.x > rangeOfMotion) &&
			(360 - rangeOfMotion > angle.x)))
		{
			// �J�����̏㉺��]
			playerCamera.transform.localEulerAngles += new Vector3(-value.y, 0, 0);
		}
	}
}