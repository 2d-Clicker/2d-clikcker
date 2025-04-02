using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public TMP_Text goldText;
    public GameObject PopupError;

    private Coroutine PopupCoroutine; //코루틴 중복 실행 방지
  
    private void Start()
    {
        if (PlayerStats.Instance == null || PlayerStats.Instance.playerData == null)
        {
            Debug.LogError("PlayerStats.Instance 또는 playerData가 존재하지 않습니다");
            return;
        }

        goldText = GameObject.Find("GoldTxt").GetComponent<TMP_Text>();
        PopupError = GameObject.Find("PopupError");

        if (PopupError != null)
        {
            PopupError.SetActive(false);
        }
        else
        {
            Debug.LogError("PopupError 오브젝트를 찾을 수 없습니다");
        }
        
        UpdateGoldUI();
    }

    public void GetGold(int amount) //골드 획득
    {
        PlayerStats.Instance.playerData.AddGold(amount);
        Debug.Log($"골드 획득. 현재 골드: {PlayerStats.Instance.playerData.gold}");
        UpdateGoldUI();
    }

    public bool SpendGold(int amount) //골드 소모
    {
        if (PlayerStats.Instance.playerData.gold >= amount)
        {
            if (PlayerStats.Instance.playerData.SpendGold(amount))
            {
                Debug.Log($"골드 사용. 남은 골드: {PlayerStats.Instance.playerData.gold}");
                UpdateGoldUI();
                return true;
            }
        }
        Debug.Log("골드 부족");
        ShowPopup();
        return false;
    }

    void ShowPopup() //골드 부족시 팝업
    {
        if(PopupCoroutine != null)
        {
            StopCoroutine(PopupCoroutine); //기존 코루틴 중지
        }

        PopupError.SetActive(true);
        PopupCoroutine = StartCoroutine(HidePopupDelay());

    }

    IEnumerator HidePopupDelay() //팝업 2초 후 사라짐
    {
        yield return new WaitForSeconds(2f);
        PopupError.SetActive(false);
    }

    private void UpdateGoldUI()
    {
        goldText.text = PlayerStats.Instance.playerData.gold.ToString();
        Debug.Log("골드 UI 갱신: " + goldText.text);
    }
}
