using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LobbyBackground : MonoBehaviour
{
    public Image displayImage;       // UI�� ǥ���� Image ������Ʈ
    public Sprite[] imageSprites;    // ������ �̹��� �迭
    public float fadeDuration = 1f;  // ���̵� ��/�ƿ� �ð�
    public float displayTime = 1.5f; // �� �̹����� �����Ǵ� �ð�

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
            // ���� �̹��� ���̵� �ƿ�
            yield return StartCoroutine(FadeOut());

            // �̹��� ����
            currentIndex = (currentIndex + 1) % imageSprites.Length;
            displayImage.sprite = imageSprites[currentIndex];

            // ���ο� �̹��� ���̵� ��
            yield return StartCoroutine(FadeIn());

            // ���� �ð� ����
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
