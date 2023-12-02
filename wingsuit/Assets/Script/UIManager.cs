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
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 UIManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<UIManager>();
            }
            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static UIManager m_instance; // 싱글톤이 할당될 static 변수

    public GameObject tutorial_pannel,nextButton, startButton,tutorial1, tutorial2, ClearTextObj;
    //public GameObject parachuteAnnae;
    public GameObject endGame_pannel;
    public Text gameoverText;

    private void Start()
    {
        Text tutorialText1 = tutorial1.GetComponent<Text>();
        Text clearText = ClearTextObj.GetComponent<Text>();
        Debug.Log("컴포넌트 받았다..........");
        tutorialText1.text = "윙슈트를 체험하러 온 "+ GameManager.playerName+"님 환영합니다.\r\n여러분은 이번 맵에서 베이스점프를 진행할 예정입니다." +
            "\r\n\r\n베이스 점프란, 윙슈트를 입고 중력과 양력을 받아 \r\n높은 절벽에서 다이빙하는 행위를 뜻하며\r\n"+ GameManager.playerName.ToString()+"님은 착지 지점에서 " +
            "다다를 때 낙하산을 펼쳐 착지할 예정입니다. ";
        clearText.text = "축하합니다 \r\n"+GameManager.playerName+"님은 베이스점프를 \r\n정복하셨습니다.";


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
            gameoverText.text = "게임을 다시 시작하기 위해서는 뭐 왼쪽 트리거를 눌러주세요";
            GameManager.instance.isGameover = true;
            Player.isStop = true;
        }
    }

}
