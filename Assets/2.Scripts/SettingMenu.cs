using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;  // AudioMixer (필요에 따라)
    public Slider bgmSlider;       // 볼륨 조절 슬라이더
    public string homeSceneName = "StartScene"; // 홈 씬 이름
    public Button homeButton;      // 홈 버튼

    void Start()
    {
        // 저장된 볼륨 불러오기
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 0.8f);
        bgmSlider.value = savedVolume;

        // 초기 볼륨
        SetBGMVolume(savedVolume);

        bgmSlider.onValueChanged.AddListener(SetBGMVolume); // 슬라이더 볼륨 조절

        if (homeButton != null)
        {
            Debug.Log("홈 버튼 이벤트 정상 등록");
            homeButton.onClick.RemoveAllListeners(); // 중복 실행 방지
            homeButton.onClick.AddListener(GoToHome);
        }
        else
        {
            Debug.LogWarning("Home 버튼이 설정되지 않았음 Inspector에서 연결해.");
        }
    }

    public void SetBGMVolume(float volume)
    {
        if (volume <= 0.01f) volume = 0.01f;
        // AudioMixer 볼륨 설정 (필요시만)
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BGMVolume", volume);

        // AudioManager를 통해 오디오 볼륨 설정
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetVolume(volume);
        }
    }

    public void GoToHome()
    {
        // 홈 씬으로 이동하기 전에 음악 변경
        Debug.Log("GoToHome() 실행됨! - 현재 씬: " + SceneManager.GetActiveScene().name);

        if (AudioManager.instance != null)
        {
            Debug.Log("AudioManager 인스턴스 존재함 음악 변경 실행");
            AudioManager.instance.SwitchToStartSceneMusic();
        }
        else
        {
            Debug.LogWarning("AudioManager 인스턴스가 존재하지 않음");
        }

            SceneManager.LoadScene(2);
    }
}
