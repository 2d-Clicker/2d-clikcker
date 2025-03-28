using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text goldText;
    public Text ErrorText;
    public GameObject PopupError;

    private Coroutine PopupCoroutine; //�ڷ�ƾ �ߺ� ���� ����
  
    private void Start()
    {
        UpdateGoldUI();

        PopupError = GameObject.Find("Coin/PopupError");
        ErrorText.gameObject.SetActive(false);
        PopupError.SetActive(false);
    }

    public void GetGold(int amount) //��� ȹ��
    {
        GameManager.Instance.playerData.gold += amount;
        UpdateGoldUI();
    }

    public bool SpendGold(int amount) //��� �Ҹ�
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

    void ShowPopup() //��� ������ �˾�
    {
        if(PopupCoroutine != null)
        {
            StopCoroutine(PopupCoroutine); //���� �ڷ�ƾ ����
        }

        PopupError.SetActive(true);
        PopupCoroutine = StartCoroutine(HidePopupDelay());

    }

    IEnumerator HidePopupDelay() //�˾� 2�� �� �����
    {
        yield return new WaitForSeconds(2f);
        PopupError.SetActive(false);
    }

    private void UpdateGoldUI()
    {
        goldText.text = "Gold: " + GameManager.Instance.playerData.gold;
    }
}
