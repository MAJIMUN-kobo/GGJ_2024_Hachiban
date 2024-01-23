using UnityEngine.InputSystem;
using UnityEngine;

// �v���C���[�N���X
public class Player : MonoBehaviour
{
	// ����
	PlayerInput input;

	// �ړ����x
	[SerializeField]
	float speed;

	// �ړ��l
	Vector3 movevalue = Vector3.zero;

	// ����
	Rigidbody rb;

	private void Awake()
	{
		// �����擾
		rb = GetComponent<Rigidbody>();

		// ���̓V�X�e������
		input = new PlayerInput();
		// ���̓V�X�e���L����
		input.Enable();

		// ���͂̃R�[���o�b�N�o�^
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
		// �ړ�
		rb.velocity = new Vector3(movevalue.x, rb.velocity.y, movevalue.z);
	}

	/// <summary>
	/// �ړ�
	/// </summary>
	/// <param name="context">���͏��</param>
	public void Move(InputAction.CallbackContext context)
	{
		// �ړ��������
		var vel = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
		// �ړ��l�̌v�Z
		movevalue = vel.normalized * speed;
	}

	/// <summary>
	/// �~�߂�
	/// </summary>
	/// <param name="context"></param>
	public void Stop(InputAction.CallbackContext context)
	{
		movevalue = Vector3.zero;
	}
}