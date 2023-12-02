using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }
            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수
    public InputField inputField; //오프닝씬에 이름을 적을 수 있는 인풋필드
    public static String playerName = ""; //게임내 데이터에 적어놓을 플레이어이름변수
    public static int playerNumber = 0;
    public bool isGameover = false;
    public bool isBaseStart = false;
    public bool isParachuteOpen = false;
    public bool isParachuteTrigger = false;
    public bool isBaseOver = false;
    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
            //스크립트에서 가장 먼저 실행되는 Awake() 메서드는 씬에 둘 이상의 GameManager
            //타입의 오브젝트가 존재하지 못하도록 막는다.
        }
    }
    

    public void BaseJumpStartButton() // 오프닝씬에 붙어있는 버튼
    {
        //시작하는사람의 이름
        playerName = inputField.text;
        if (String.IsNullOrEmpty(playerName))
        {
            playerName = "User_"+ UnityEngine.Random.Range(1,999);
        }
        //PlayerPrefs.SetString(playerNumber++.ToString(), playerName);
        //엔딩씬에서 돌아와서 다시 게임을 하겠다는 사람을 위해 스코어 초기화
        SceneManager.LoadScene("BaseJumpScene");
        Player.isStop = true;
    }

    public void JetPackStartButton()
    {
        playerName = inputField.text;
        if (String.IsNullOrEmpty(playerName))
        {
            playerName = "User_" + UnityEngine.Random.Range(1, 999);

        }
        //PlayerPrefs.SetString(playerNumber++.ToString(), playerName);

        SceneManager.LoadScene("JetPackScene");
    }
    
    public void ExitButton()
    {
#if UNITY_EDITOR
        // 에디터에서는 종료되지 않으므로 에디터 화면만 닫습니다.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 게임에서는 게임을 종료합니다.
        Application.Quit();
#endif
    }
    private void Update()
    {
        if (isBaseStart)
        {
            if (isGameover)
            {
                if (Input.GetKey(KeyCode.R))
                {
                    string currentSceneName = SceneManager.GetActiveScene().name;
                    Debug.Log("a");
                    SceneManager.LoadScene(currentSceneName);
                    isGameover = false;
                }
            }
        }

    }




}
