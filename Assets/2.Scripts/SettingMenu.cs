using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;  // AudioMixer (�ʿ信 ����)
    public Slider bgmSlider;       // ���� ���� �����̴�
    public string homeSceneName = "StartScene"; // Ȩ �� �̸�
    public Button homeButton;      // Ȩ ��ư

    void Start()
    {
        // ����� ���� �ҷ�����
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 0.8f);
        bgmSlider.value = savedVolume;

        // �ʱ� ����
        SetBGMVolume(savedVolume);

        bgmSlider.onValueChanged.AddListener(SetBGMVolume); // �����̴� ���� ����

        if (homeButton != null)
        {
            Debug.Log("Ȩ ��ư �̺�Ʈ ���� ���");
            homeButton.onClick.RemoveAllListeners(); // �ߺ� ���� ����
            homeButton.onClick.AddListener(GoToHome);
        }
        else
        {
            Debug.LogWarning("Home ��ư�� �������� �ʾ��� Inspector���� ������.");
        }
    }

    public void SetBGMVolume(float volume)
    {
        if (volume <= 0.01f) volume = 0.01f;
        // AudioMixer ���� ���� (�ʿ�ø�)
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BGMVolume", volume);

        // AudioManager�� ���� ����� ���� ����
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetVolume(volume);
        }
    }

    public void GoToHome()
    {
        // Ȩ ������ �̵��ϱ� ���� ���� ����
        Debug.Log("GoToHome() �����! - ���� ��: " + SceneManager.GetActiveScene().name);

        if (AudioManager.instance != null)
        {
            Debug.Log("AudioManager �ν��Ͻ� ������ ���� ���� ����");
            AudioManager.instance.SwitchToStartSceneMusic();
        }
        else
        {
            Debug.LogWarning("AudioManager �ν��Ͻ��� �������� ����");
        }

            SceneManager.LoadScene(2);
    }
}
