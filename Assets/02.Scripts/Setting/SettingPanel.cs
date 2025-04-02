using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsPanel : MonoBehaviour
{
    public GameObject settingsPanel;  // 설정 패널
    public Slider bgmSlider;          // 배경음악 슬라이더
    public AudioSource bgmSource;      // 배경음악 오디오 소스
    public Button settingBtn;
    public Button homeBtn;

    private void Start()
    {
        // 저장된 배경음악 볼륨 불러오기
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        bgmSlider.value = savedVolume;
        bgmSource.volume = savedVolume;

        // 슬라이더 값이 변경될 때 볼륨 조정
        bgmSlider.onValueChanged.AddListener(ChangeBGMVolume);
    }

    
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f; // 게임 일시정지
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
    }

    public void ChangeBGMVolume(float value)
    {
        bgmSource.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
        PlayerPrefs.Save();
    }

    public void GoToHome()
    {
        Time.timeScale = 1f; // 씬 이동 전 게임 속도 복구
        SceneManager.LoadScene("StartScene"); // 메인 메뉴 씬으로 이동
    }
}
