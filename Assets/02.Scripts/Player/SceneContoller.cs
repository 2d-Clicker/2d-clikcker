using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public AudioSource buttonClickSound; // 버튼 클릭 소리
    public float delayBeforeSceneChange = 0.3f; // 씬 전환 전 딜레이
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




