using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text goldText;
    public Text ErrorText;
    public GameObject PopupError;

    private Coroutine PopupCoroutine; //코루틴 중복 실행 방지
  
    private void Start()
    {
        UpdateGoldUI();

        PopupError = GameObject.Find("Coin/PopupError");
        ErrorText.gameObject.SetActive(false);
        PopupError.SetActive(false);
    }

    public void GetGold(int amount) //골드 획득
    {
        GameManager.Instance.playerData.gold += amount;
        UpdateGoldUI();
    }

    public bool SpendGold(int amount) //골드 소모
    {
        if (GameManager.Instance.playerData.gold >= amount)
        {
            GameManager.Instance.playerData.gold -= amount;
            UpdateGoldUI();
            return true;
        }
        else
        {
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
        goldText.text = "Gold: " + GameManager.Instance.playerData.gold;
    }
}
