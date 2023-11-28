using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;
    bool sDown; // �߰�: ������ ���� ����
    bool jDown;

    bool isJump;
    public static bool isStop;
    Vector3 moveVec;

    Rigidbody rigid;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
       
        Move();
        // �̵� ���� ���� ó���ϴ� �ٸ� �Լ� ȣ��
        Turn();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        sDown = Input.GetKey(KeyCode.S); // �߰�: S Ű �Է� Ȯ��
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        // ī�޶� ������ ��������
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        // �̵� ���� ����
        

        // ī�޶� �������� �̵�
        if (isStop)
        {
            Debug.Log("isStop �Ȼ�Ȳ");
        }
        else
        {
            moveVec = new Vector3(hAxis, 0, vAxis).normalized;
            transform.position += (cameraForward * moveVec.z + Camera.main.transform.right * moveVec.x) * speed * (wDown ? 0.3f : 0.5f) * Time.deltaTime;

            // �ִϸ��̼� ����
            anim.SetBool("isRun", moveVec != Vector3.zero);
            anim.SetBool("isWalk", wDown);
        }
        
    }

    void Turn()
    {
        // desiredDirection ����
        Vector3 desiredDirection = wDown ? moveVec : (sDown ? -moveVec : Vector3.zero);
        desiredDirection = desiredDirection.normalized;

        // ���콺�� �����̴� �������� ȸ��
        float mouseX = Input.GetAxis("Mouse X");
        if (Mathf.Abs(mouseX) > 0.1f)
        {
            Vector3 horizontalRotation = Vector3.up * mouseX * 10f;
            transform.Rotate(horizontalRotation);
        }
        // �̵� ���� �� ȸ�� ����
        else if (desiredDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(desiredDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 10f);
        }
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 600, ForceMode.Impulse);
            isJump = true;
            anim.SetTrigger("doJump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
            anim.SetBool("isJump", false);
        }
    }
}
