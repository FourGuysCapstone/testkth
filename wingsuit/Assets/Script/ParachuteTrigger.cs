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
        // 충돌한 오브젝트가 플레이어인지 확인
        if (other.CompareTag("Player"))
        {
            Debug.Log("트리거가 진입되었습니다.");

            // 상호작용할 오브젝트를 활성화
            if (player != null)
            {
                Debug.Log("플레이어가 낙하산트리거에 진입했습니다.");
                annae.text = "낙하산을 펼치는 키는 X입니다.";
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
