using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(PulseEffect());
    }

    IEnumerator PulseEffect()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.05f;

        float duration = 0.5f; //사이즈의 변경까지 걸리는 시간 

        while (true)
        {
            // 커지기
            yield return LerpScale(originalScale, targetScale, duration);

            // 작아지기
            yield return LerpScale(targetScale, originalScale, duration);
        }
    }

    IEnumerator LerpScale(Vector3 from, Vector3 to, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            transform.localScale = Vector3.Lerp(from, to, t);
            yield return null;
        }
    }

}
