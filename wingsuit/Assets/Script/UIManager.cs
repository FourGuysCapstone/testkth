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
        gameoverText.text = "게임을 다시 시작하기 위해서는 뭐 왼쪽 트리거를 눌러주세요";
        GameManager.instance.isGameover = true;
        Player.isStop = true;
    }

}
