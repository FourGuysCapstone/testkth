using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;
    bool sDown; // 추가: 후진을 위한 변수
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
        // 이동 로직 등을 처리하는 다른 함수 호출
        Turn();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        sDown = Input.GetKey(KeyCode.S); // 추가: S 키 입력 확인
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        // 카메라 방향을 가져오기
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        // 이동 벡터 설정
        

        // 카메라 방향으로 이동
        if (isStop)
        {
            Debug.Log("isStop 된상황");
        }
        else
        {
            moveVec = new Vector3(hAxis, 0, vAxis).normalized;
            transform.position += (cameraForward * moveVec.z + Camera.main.transform.right * moveVec.x) * speed * (wDown ? 0.3f : 0.5f) * Time.deltaTime;

            // 애니메이션 설정
            anim.SetBool("isRun", moveVec != Vector3.zero);
            anim.SetBool("isWalk", wDown);
        }
        
    }

    void Turn()
    {
        // desiredDirection 설정
        Vector3 desiredDirection = wDown ? moveVec : (sDown ? -moveVec : Vector3.zero);
        desiredDirection = desiredDirection.normalized;

        // 마우스가 움직이는 방향으로 회전
        float mouseX = Input.GetAxis("Mouse X");
        if (Mathf.Abs(mouseX) > 0.1f)
        {
            Vector3 horizontalRotation = Vector3.up * mouseX * 10f;
            transform.Rotate(horizontalRotation);
        }
        // 이동 중일 때 회전 적용
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
