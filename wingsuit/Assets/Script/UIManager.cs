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

    public GameObject tutorial_pannel,nextButton, startButton,tutorial1, tutorial2, ClearTextObj;
    //public GameObject parachuteAnnae;
    public GameObject endGame_pannel;
    public Text gameoverText;

    private void Start()
    {
        Text tutorialText1 = tutorial1.GetComponent<Text>();
        Text clearText = ClearTextObj.GetComponent<Text>();
        Debug.Log("������Ʈ �޾Ҵ�..........");
        tutorialText1.text = "����Ʈ�� ü���Ϸ� �� "+ GameManager.playerName+"�� ȯ���մϴ�.\r\n�������� �̹� �ʿ��� ���̽������� ������ �����Դϴ�." +
            "\r\n\r\n���̽� ������, ����Ʈ�� �԰� �߷°� ����� �޾� \r\n���� �������� ���̺��ϴ� ������ ���ϸ�\r\n"+ GameManager.playerName.ToString()+"���� ���� �������� " +
            "�ٴٸ� �� ���ϻ��� ���� ������ �����Դϴ�. ";
        clearText.text = "�����մϴ� \r\n"+GameManager.playerName+"���� ���̽������� \r\n�����ϼ̽��ϴ�.";


    }


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
    public void JetPackButton()
    {
        SceneManager.LoadScene("JetPackScene");
    }

    public void Reload()
    {
        if (GameManager.instance.isBaseStart) {
            gameoverText.text = "������ �ٽ� �����ϱ� ���ؼ��� �� ���� Ʈ���Ÿ� �����ּ���";
            GameManager.instance.isGameover = true;
            Player.isStop = true;
        }
    }

}
