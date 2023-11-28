using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArea : MonoBehaviour
{
    public GameObject firstPlayer, interactableObject, interactableCamera, me;
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 플레이어인지 확인
        if (other.CompareTag("Player"))
        {
            Debug.Log("트리거가 진입되었습니다.");

            // 상호작용할 오브젝트를 활성화
            if (interactableObject != null)
            {
                Debug.Log("플레이어가 트리거에 진입했습니다.");

                interactableObject.SetActive(true);
                interactableCamera.SetActive(true);
                firstPlayer.SetActive(false);
            }
            Destroy(me);
        }
    }
}
