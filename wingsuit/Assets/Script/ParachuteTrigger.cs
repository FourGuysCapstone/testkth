using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParachuteTrigger : MonoBehaviour
{
    public GameObject player;
    public Text annae;
    [SerializeField]
    private AviatorController controller;
    [SerializeField]
    private JointsPoseController
        posControlle;

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
                GameManager.instance.isParachuteTrigger = true;
            }
        }
    }
    private void Update()
    {
        if (GameManager.instance.isParachuteTrigger)
        {
            if(Input.GetKey(KeyCode.X))
            {
                GameManager.instance.isParachuteOpen = true;
                controller.parachuteIsOpened = true;
                posControlle.SetPose("Open parachute", 1.0f);
                GameManager.instance.isParachuteTrigger = false;
                annae.text = "";
            }
            
        }
        
        if (GameManager.instance.isGameover || GameManager.instance.isBaseOver)
        {
            annae.text = "";
        }
    }
}
