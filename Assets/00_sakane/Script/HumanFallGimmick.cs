using UnityEngine;
using Cysharp.Threading.Tasks;

// �]�Ԑl�̃M�~�b�N
public class HumanFallGimmick : GimmickBehaviour
{
	// �ړ����x
	[SerializeField]
	float movespeed;

	// ����
	Rigidbody rb;

	// �]�Ԃ܂ł̎���
	[SerializeField]
	float fallTime;

	// �A�j���[�^�[
	Animator animator;

	// �^�[�Q�b�g�i�v���C���[�j
	GameObject target;

	// �^�[�Q�b�g��������ő勗��
	[SerializeField]
	float distance;

	// �^�[�Q�b�g��������p�x
	[SerializeField]
	float angle;

	// true = �ǂ������Ă���
	bool isChasing;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();

		animator = GetComponent<Animator>();

#if UNITY_EDITOR
		// �f�o�b�O�p
		{
			rb.velocity = transform.forward * movespeed;
			StopRunning().Forget();
		}
#endif
	}

	private void Update()
	{
		// �ǂ������Ă��鎞�Ƀ^�[�Q�b�g�����E�ɂ��邩�m�F
		if (isChasing)
		{
			if (!IsVisibilityTarget())
			{
				// ���E����O�ꂽ��]��
				StopRunning().Forget();
			}
		}
	}

	public override void OnLookAtActivation(GameObject target)
	{
		// ����
		var direction = transform.position - target.transform.position;
		// �ړ�
		rb.velocity = direction * movespeed;
		// �ǂ������n�߂�
		isChasing = true;
		// �^�[�Q�b�g�ݒ�
		this.target = target;
	}

	/// <summary>
	/// �]��
	/// </summary>
	/// <returns></returns>
	async UniTask StopRunning()
	{
		// �g�[�N���擾
		var token = this.GetCancellationTokenOnDestroy();
		// �����҂�
		await UniTask.WaitForSeconds(fallTime, cancellationToken: token);
		// �A�j���[�V�����Đ�
		animator.SetTrigger("Fall");
	}

	/// <summary>
	/// ���E�Ƀ^�[�Q�b�g�����邩���ׂ�
	/// </summary>
	/// <returns>true = �^�[�Q�b�g</returns>
	public bool IsVisibilityTarget()
	{
		// ���g�̈ʒu
		var selfPos = transform.position;
		// �^�[�Q�b�g�̈ʒu
		var targetPos = target.transform.position;

		// ���g�̌����i���K�����ꂽ�x�N�g���j
		var selfDir = transform.forward;

		// �^�[�Q�b�g�܂ł̌����Ƌ����v�Z
		var targetDir = targetPos - selfPos;
		var targetDistance = targetDir.magnitude;

		// cos(��/2)���v�Z
		var cosHalf = Mathf.Cos(angle / 2 * Mathf.Deg2Rad);

		// ���g�ƃ^�[�Q�b�g�ւ̌����̓��όv�Z
		// �^�[�Q�b�g�ւ̌����x�N�g���𐳋K������K�v�����邱�Ƃɒ���
		var innerProduct = Vector3.Dot(selfDir, targetDir.normalized);

		// ���E����
		return innerProduct > cosHalf && targetDistance < distance;
	}
}