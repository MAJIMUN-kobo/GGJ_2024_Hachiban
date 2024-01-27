using UnityEngine;

public class HumanDownGimmick : GimmickBehaviour
{
	// �A�j���[�V����
	Animator animator;
	// ����
	Rigidbody rb;
	// true = �����Ă���
	bool isRunning = false;
	// ���x
	[SerializeField]
	float speed;

	[SerializeField]
	float adjustment;

	private void Awake()
	{
		// �A�j���[�V�����擾
		animator = GetComponent<Animator>();
		// �����擾
		rb = GetComponent<Rigidbody>();

#if UNITY_EDITOR

		Run();

#endif
	}

	private void FixedUpdate()
	{
		if (isRunning)
		{
			// �ړ�
			rb.velocity = transform.forward * speed;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		// �t���A�A�v���C���[�A�ȊO�ŁA�����Ă����Ԃ�������Փ�
		if (!collision.gameObject.CompareTag("Floor") &&
			!collision.gameObject.CompareTag("Player") &&
			isRunning)
		{
			transform.position += transform.forward * adjustment;
			transform.localEulerAngles += new Vector3(0, 180, 0);
			// �A�j���[�V�����Đ�
			animator.SetTrigger("Down");
			// �������~�߂�
			rb.velocity = Vector3.zero;
			// �d�͖���
			rb.useGravity = false;
			// ��������
			rb.isKinematic = true;
			// �R���C�_�[����
			GetComponent<Collider>().enabled = false;
		}
	}

	/// <summary>
	/// ����
	/// </summary>
	void Run()
	{
		// ����A�j���[�V����
		animator.SetTrigger("Run");

		isRunning = true;
	}
}