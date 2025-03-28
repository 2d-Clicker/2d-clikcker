using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentDataManager : MonoBehaviour
{
    public Text goldText;
    public Text ErrorText;

    private void Start()
    {
        UpdateGoldUI();
        ErrorText.gameObject.SetActive(false);
    }

    public void EarnGold(int amount)
    {
        GameManager.Instance.playerData.gold += amount;
        UpdateGoldUI();
    }

    public bool SpendGold(int amount)
    {
        if (GameManager.Instance.playerData.gold >= amount)
        {
            GameManager.Instance.playerData.gold -= amount;
            UpdateGoldUI();
            return true;
        }
        else
        {
            StartCoroutine(ShowWarning("Gold ∫Œ¡∑!"));
            return false;
        }
    }

    private void UpdateGoldUI()
    {
        goldText.text = "Gold: " + GameManager.Instance.playerData.gold;
    }

    private IEnumerator ShowWarning(string message)
    {
        ErrorText.text = message;
        ErrorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        ErrorText.gameObject.SetActive(false);
    }
}
