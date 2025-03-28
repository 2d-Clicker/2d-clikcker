using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public TMP_Text goldText;
    public GameObject PopupError;

    private Coroutine PopupCoroutine; //�ڷ�ƾ �ߺ� ���� ����
  
    private void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance�� null�Դϴ�! ���� GameManager ������Ʈ�� �ִ��� Ȯ���ϼ���.");
            return;
        }

        UpdateGoldUI();

        goldText = GameObject.Find("Coin/GoldTxt").GetComponent<TMP_Text>();
        PopupError = GameObject.Find("Coin/PopupError");
        PopupError.gameObject.SetActive(false);
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
        goldText.text =  ""+GameManager.Instance.playerData.gold;
    }
}
