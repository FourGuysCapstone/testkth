using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player; // ī�޶� ���� ��� (�÷��̾� ��)
    public float sensitivity = 2.0f; // ���콺 ����

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned for FirstPersonCamera!");
            return;
        }

        // ���콺 �Է��� ���� ȸ��
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // ���� ȸ�� (����)
        float rotationX = transform.rotation.eulerAngles.x - mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // ���� ���� ����
        transform.rotation = Quaternion.Euler(rotationX, transform.rotation.eulerAngles.y, 0);

        // ���� ȸ�� (�¿�)
        player.Rotate(Vector3.up * mouseX);

        // ������ �Է¿� ���� �̵�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // �÷��̾ ���󰡸鼭 �̵�
        Vector3 moveDir = player.TransformDirection(inputDir);
        player.Translate(moveDir * Time.deltaTime * 5f);
    }
}
