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

    public bool SpendGold(int amount) //��� �Ҹ�
    {
        if (PlayerStats.Instance.playerData.gold >= amount)
        {
            if (PlayerStats.Instance.playerData.SpendGold(amount))
            {
                Debug.Log($"��� ���. ���� ���: {PlayerStats.Instance.playerData.gold}");
                UpdateGoldUI();
                return true;
            }
        }
        Debug.Log("��� ����");
        ShowPopup();
        return false;
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
        goldText.text = PlayerStats.Instance.playerData.gold.ToString();
        Debug.Log("��� UI ����: " + goldText.text);
    }
}
