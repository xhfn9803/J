using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Vector3 moveForce;

    [SerializeField]
    private float jumpForce; //���� ��
    [SerializeField]
    private float gravity; //�߷°��




    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }
    private CharacterController characterController;

    private void Awake()
    {

        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //����� �������� �߷¸�ŭ Y�� �̵��ӵ� ���
        if ( !characterController.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }

        //1�ʴ� moveForce �ӷ����� �̵�
        characterController.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        //�̵� ���� = ĳ������ ȸ�� �� * ���� ��
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        //�̵� �� = �̵����� * �ӵ�
        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void Jump()
    {
        // �÷��̾ �ٴڿ� ���� ���� ���� ����
        if( characterController.isGrounded)
        {
            moveForce.y = jumpForce;
        }
    }

}

