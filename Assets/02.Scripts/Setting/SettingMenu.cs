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
    public Button settingBtn;
    public GameObject clickArea;

    public GameObject InSettingPanel;
    public Button ExitBtn;

    void Start()
    {
        if (InSettingPanel != null)
        {
            InSettingPanel.SetActive(false);
        }

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

        if (settingBtn != null)
        {
            settingBtn.onClick.RemoveAllListeners();
            settingBtn.onClick.AddListener(ToggleSettingPanel);
        }

        if (ExitBtn != null) //Exit ��ư
        {
            ExitBtn.onClick.RemoveAllListeners();
            ExitBtn.onClick.AddListener(ToggleSettingPanel);
        }
        else
        {
            Debug.LogWarning("ExitBtn�� �������� ���� Inspector���� �����ϱ�.");
        }
    }
    
    private void ToggleSettingPanel()
    {
        if (InSettingPanel != null)
        {
            bool isPanelActive = InSettingPanel.activeSelf;
            InSettingPanel.SetActive(!InSettingPanel.activeSelf);

            if(clickArea != null)
            {
                clickArea.SetActive(isPanelActive);
            }

            // ���� �簳
            if (isPanelActive) 
            {
                Time.timeScale = 1f; 
            }
            else //���� �Ͻ�����
            {
                Time.timeScale = 0f; 
            }
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