using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ UIManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<UIManager>();
            }
            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static UIManager m_instance; // �̱����� �Ҵ�� static ����

    public GameObject tutorial_pannel,nextButton, startButton,tutorial1, tutorial2;
    public Text gameoverText;

    public void NextButton()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
        nextButton.SetActive(false); 
        startButton.SetActive(true);
    }

    public void StartButton()
    {
        tutorial_pannel.SetActive(false);
        Player.isStop = false;
    }

    public void Reload()
    {
        gameoverText.text = "������ �ٽ� �����ϱ� ���ؼ��� �� ���� Ʈ���Ÿ� �����ּ���";
        GameManager.instance.isGameover = true;
        Player.isStop = true;
    }

}
