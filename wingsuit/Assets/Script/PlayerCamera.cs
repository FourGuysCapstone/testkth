using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player; // 카메라가 따라갈 대상 (플레이어 등)
    public float sensitivity = 2.0f; // 마우스 감도

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned for FirstPersonCamera!");
            return;
        }

        // 마우스 입력을 통한 회전
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // 수직 회전 (상하)
        float rotationX = transform.rotation.eulerAngles.x - mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // 상하 각도 제한
        transform.rotation = Quaternion.Euler(rotationX, transform.rotation.eulerAngles.y, 0);

        // 수평 회전 (좌우)
        player.Rotate(Vector3.up * mouseX);

        // 움직임 입력에 따라 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // 플레이어를 따라가면서 이동
        Vector3 moveDir = player.TransformDirection(inputDir);
        player.Translate(moveDir * Time.deltaTime * 5f);
    }
}
