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
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<GameManager>();
            }
            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static GameManager m_instance; // �̱����� �Ҵ�� static ����
    public InputField inputField; //�����׾��� �̸��� ���� �� �ִ� ��ǲ�ʵ�
    public static String playerName = ""; //���ӳ� �����Ϳ� ������� �÷��̾��̸�����
    // �÷��̾�� ��ȣ�ۿ��� ������Ʈ
    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
            //��ũ��Ʈ���� ���� ���� ����Ǵ� Awake() �޼���� ���� �� �̻��� GameManager
            //Ÿ���� ������Ʈ�� �������� ���ϵ��� ���´�.
        }
    }

    public void BaseJumpStartButton() // �����׾��� �پ��ִ� ��ư
    {
        //�����ϴ»���� �̸�
        playerName = inputField.text;
        //���������� ���ƿͼ� �ٽ� ������ �ϰڴٴ� ����� ���� ���ھ� �ʱ�ȭ
        SceneManager.LoadScene("BaseJumpScene");
    }

    public void JetPackStartButton()
    {
        playerName = inputField.text;
        SceneManager.LoadScene("JetPackScene");
    }
    public void ExitButton()
    {
#if UNITY_EDITOR
        // �����Ϳ����� ������� �����Ƿ� ������ ȭ�鸸 �ݽ��ϴ�.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ����� ���ӿ����� ������ �����մϴ�.
        Application.Quit();
#endif
    }
    



}
