using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArea : MonoBehaviour
{
    public GameObject firstPlayer, interactableObject, interactableCamera, me;
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �÷��̾����� Ȯ��
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ʈ���Ű� ���ԵǾ����ϴ�.");

            // ��ȣ�ۿ��� ������Ʈ�� Ȱ��ȭ
            if (interactableObject != null)
            {
                Debug.Log("�÷��̾ Ʈ���ſ� �����߽��ϴ�.");

                interactableObject.SetActive(true);
                interactableCamera.SetActive(true);
                firstPlayer.SetActive(false);
            }
            Destroy(me);
        }
    }
}
