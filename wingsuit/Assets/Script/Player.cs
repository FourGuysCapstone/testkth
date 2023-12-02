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

        // Rigidbody 컴포넌트 가져오기
        Rigidbody rb = GetComponent<Rigidbody>();

        // 마우스가 움직이는 방향으로 회전
        float mouseX = Input.GetAxis("Mouse X");
        if (Mathf.Abs(mouseX) > 0.015f)
        {
            // 원래는 Rigidbody를 사용하지만, freezeRotation을 이용해 물리 회전을 제한하고자
            // transform.Rotate를 사용합니다.
            Vector3 horizontalRotation = Vector3.up * mouseX * 10f;

            // 플레이어 자체를 회전
            transform.Rotate(horizontalRotation);

            // "Root"도 같이 회전 (Root의 부모가 플레이어일 경우에만 해당)
            transform.Find("Root").Rotate(horizontalRotation);
        }
        // 이동 중일 때 회전 적용
        else if (desiredDirection != Vector3.zero)
        {
            // 이동 방향으로 회전하는 부분을 "Root" 오브젝트에 적용
            Quaternion toRotation = Quaternion.LookRotation(desiredDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 10f);

            // "Root"도 같이 회전 (Root의 부모가 플레이어일 경우에만 해당)
            transform.Find("Root").rotation = Quaternion.Lerp(transform.Find("Root").rotation, toRotation, Time.deltaTime * 10f);
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
