using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsPanel : MonoBehaviour
{
    public GameObject settingsPanel;  // ���� �г�
    public Slider bgmSlider;          // ������� �����̴�
    public AudioSource bgmSource;      // ������� ����� �ҽ�
    public Button settingBtn;
    public Button homeBtn;

    private void Start()
    {
        // ����� ������� ���� �ҷ�����
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        bgmSlider.value = savedVolume;
        bgmSource.volume = savedVolume;

        // �����̴� ���� ����� �� ���� ����
        bgmSlider.onValueChanged.AddListener(ChangeBGMVolume);
    }

    
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f; // ���� �Ͻ�����
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f; // ���� �簳
    }

    public void ChangeBGMVolume(float value)
    {
        bgmSource.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
        PlayerPrefs.Save();
    }

    public void GoToHome()
    {
        Time.timeScale = 1f; // �� �̵� �� ���� �ӵ� ����
        SceneManager.LoadScene("StartScene"); // ���� �޴� ������ �̵�
    }
}
