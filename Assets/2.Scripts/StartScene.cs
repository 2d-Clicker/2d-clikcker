using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void LoadScene(string Name)
    {
        SceneManager.LoadScene(Name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
