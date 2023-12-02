using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndArea : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �÷��̾����� Ȯ��
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ʈ���Ű� ���ԵǾ����ϴ�.");
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            // Check if the player has a Rigidbody
            if (playerRigidbody != null)
            {
                playerRigidbody.position = new Vector3 (882.3758f, 2.5f, 540.5494f);
            }
            if (GameManager.instance.isParachuteOpen) {
                UIManager.instance.endGame_pannel.SetActive(true);
                GameManager.instance.isBaseStart = false;
                GameManager.instance.isBaseOver = true;
            }
            else if(!GameManager.instance.isParachuteOpen)
            {
                
                UIManager.instance.Reload();
            }



        }
    }
}
