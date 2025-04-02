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
        if (PlayerStats.Instance == null || PlayerStats.Instance.playerData == null)
        {
            Debug.LogError("PlayerStats.Instance �Ǵ� playerData�� �������� �ʽ��ϴ�");
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
            Debug.LogError("PopupError ������Ʈ�� ã�� �� �����ϴ�");
        }
        
        UpdateGoldUI();
    }

    public void GetGold(int amount) //��� ȹ��
    {
        PlayerStats.Instance.playerData.AddGold(amount);
        Debug.Log($"��� ȹ��. ���� ���: {PlayerStats.Instance.playerData.gold}");
        UpdateGoldUI();
    }

    public bool SpendGold(int amount)
{
    if (PlayerStats.Instance.playerData.gold >= amount)
    {
        PlayerStats.Instance.playerData.gold -= amount;
        Debug.Log($"��� ���: {amount} | ���� ���: {PlayerStats.Instance.playerData.gold}");
        
        // ��� UI ������Ʈ
        GoldManager goldManager = GameObject.FindObjectOfType<GoldManager>();
        if (goldManager != null)
        {
            goldManager.UpdateGoldUI();
        }
        else
        {
            Debug.LogError("GoldManager�� ã�� �� �����ϴ�! UI ������Ʈ ����");
        }

        return true;
    }
    Debug.Log("��� ����! ���� �Ұ�.");
        ShowPopup();
        return false;
}

    public void ShowPopup() //��� ������ �˾�
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

    public int GetCurrentGold() //���� ��带 ��ȯ�ϴ� ����
    {
        return PlayerStats.Instance.playerData.gold;
    }

    public void UpdateGoldUI()
    {
        goldText.text = PlayerStats.Instance.playerData.gold.ToString();
        Debug.Log("��� UI ����: " + goldText.text);
    }
}
