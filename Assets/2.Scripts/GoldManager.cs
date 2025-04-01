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
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance가 null입니다! 씬에 GameManager 오브젝트가 있는지 확인하세요.");
            return;
        }

        UpdateGoldUI();

        goldText = GameObject.Find("GoldTxt").GetComponent<TMP_Text>();
        PopupError = GameObject.Find("PopupError");
        PopupError.gameObject.SetActive(false);
        PopupError.SetActive(false);

        if (PopupError != null)
        {
            PopupError.SetActive(false);
        }
        else
        {
            Debug.LogError("PopupError 오브젝트를 찾을 수 없습니다!");
        }
    }

    public void GetGold(int amount) //골드 획득
    {
        GameManager.Instance.playerData.gold += amount;
        Debug.Log($"골드 사용. 남은 골드: {GameManager.Instance.playerData.gold}");
        UpdateGoldUI();
    }

    public bool SpendGold(int amount) //골드 소모
    {
        if (GameManager.Instance.playerData.gold >= amount)
        {
            GameManager.Instance.playerData.gold -= amount;
            Debug.Log($"골드 사용. 남은 골드: {GameManager.Instance.playerData.gold}");
            UpdateGoldUI();
            return true;
        }
        else
        {
            Debug.Log("골드 부족");
            ShowPopup();
            return false;
        }
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
        goldText.text =  ""+GameManager.Instance.playerData.gold;
        Debug.Log("골드UI 갱신: " + goldText.text); 
    }
}
