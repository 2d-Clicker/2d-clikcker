using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip gameMusic;   // ���� ������ ����� ����
    public AudioClip startSceneMusic;  // StartScene���� ����� ����

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� AudioManager�� �����ǵ��� ����
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }
    void Start()
    {
        Debug.Log("AudioManager ���� ��: " + SceneManager.GetActiveScene().name);
    }

    public void SwitchToGameMusic()
    {
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    public void SwitchToStartSceneMusic()
    {
        Debug.Log("SwitchToStartSceneMusic �����"); // ����� �ڵ� �߰�
        audioSource.clip = startSceneMusic;
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
