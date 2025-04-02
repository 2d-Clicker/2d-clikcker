using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LobbyBackground : MonoBehaviour
{
    public Image displayImage;       // UI에 표시할 Image 컴포넌트
    public Sprite[] imageSprites;    // 변경할 이미지 배열
    public float fadeDuration = 1f;  // 페이드 인/아웃 시간
    public float displayTime = 1.5f; // 한 이미지가 유지되는 시간

    private int currentIndex = 0;
    private Color imageColor;

    void Start()
    {
        if (imageSprites.Length > 0)
        {
            imageColor = displayImage.color;
            StartCoroutine(ChangeImageRoutine());
        }
    }

    IEnumerator ChangeImageRoutine()
    {
        while (true)
        {
            // 현재 이미지 페이드 아웃
            yield return StartCoroutine(FadeOut());

            // 이미지 변경
            currentIndex = (currentIndex + 1) % imageSprites.Length;
            displayImage.sprite = imageSprites[currentIndex];

            // 새로운 이미지 페이드 인
            yield return StartCoroutine(FadeIn());

            // 일정 시간 유지
            yield return new WaitForSeconds(displayTime);
        }
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            imageColor.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            displayImage.color = imageColor;
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            imageColor.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            displayImage.color = imageColor;
            yield return null;
        }
    }
}
