using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParachuteTrigger : MonoBehaviour
{
    public GameObject player;
    public Text annae;
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �÷��̾����� Ȯ��
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ʈ���Ű� ���ԵǾ����ϴ�.");

            // ��ȣ�ۿ��� ������Ʈ�� Ȱ��ȭ
            if (player != null)
            {
                Debug.Log("�÷��̾ ���ϻ�Ʈ���ſ� �����߽��ϴ�.");
                annae.text = "���ϻ��� ��ġ�� Ű�� X�Դϴ�.";
                
            }
        }
    }
    private void Update()
    {
        if (GameManager.instance.isGameover)
        {
            annae.text = "";
        }
    }
}
