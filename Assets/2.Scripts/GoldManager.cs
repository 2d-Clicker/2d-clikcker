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
            Debug.LogError("PopupError ������Ʈ�� ã�� �� �����ϴ�!");
        }
    }

    public void GetGold(int amount) //��� ȹ��
    {
        GameManager.Instance.playerData.gold += amount;
        Debug.Log($"��� ���. ���� ���: {GameManager.Instance.playerData.gold}");
        UpdateGoldUI();
    }

    public bool SpendGold(int amount) //��� �Ҹ�
    {
        if (GameManager.Instance.playerData.gold >= amount)
        {
            GameManager.Instance.playerData.gold -= amount;
            Debug.Log($"��� ���. ���� ���: {GameManager.Instance.playerData.gold}");
            UpdateGoldUI();
            return true;
        }
        else
        {
            Debug.Log("��� ����");
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
        Debug.Log("���UI ����: " + goldText.text); 
    }
}
