using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip gameMusic;   // 게임 씬에서 사용할 음악
    public AudioClip startSceneMusic;  // StartScene에서 사용할 음악

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 AudioManager가 유지되도록 설정
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }
    void Start()
    {
        Debug.Log("AudioManager 현재 씬: " + SceneManager.GetActiveScene().name);
    }

    public void SwitchToGameMusic()
    {
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    public void SwitchToStartSceneMusic()
    {
        Debug.Log("SwitchToStartSceneMusic 실행됨"); // 디버깅 코드 추가
        audioSource.clip = startSceneMusic;
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
