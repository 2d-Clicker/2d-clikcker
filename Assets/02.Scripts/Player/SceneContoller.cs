using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public AudioSource buttonClickSound; // ��ư Ŭ�� �Ҹ�
    public float delayBeforeSceneChange = 0.3f; // �� ��ȯ �� ������
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
    public void OnButtonClick(string sceneName)
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play(); 
        }

        Invoke("ChangeScene", delayBeforeSceneChange); 
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("MainScene 1"); 
    }
}




