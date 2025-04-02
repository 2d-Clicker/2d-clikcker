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

        float duration = 0.5f; //�������� ������� �ɸ��� �ð� 

        while (true)
        {
            // Ŀ����
            yield return LerpScale(originalScale, targetScale, duration);

            // �۾�����
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
