using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeButton : MonoBehaviour
{
    public WeaponManager weaponManager; // WeaponManager 참조
    public string weaponKey;
    private int clickCount = 0; // 클릭 횟수 추적

    void Start()
    {
        // 버튼 클릭 시 강화 함수 호출
        GetComponent<Button>().onClick.AddListener(OnUpgradeButtonClicked);
    }

    // 강화 버튼 클릭 시 호출되는 함수
    private void OnUpgradeButtonClicked()
    {
        if (clickCount >= 2)
        {
            // 두 번 클릭 이후에는 더 이상 클릭되지 않도록 함
            return;
        }

        clickCount++; // 클릭 횟수 증가

        if (weaponManager != null)
        {
            // weaponKey에 해당하는 무기를 강화합니다.
            weaponManager.UpgradeWeapon(weaponKey); // 강화 함수에 무기 키를 전달
        }

        // 두 번 클릭 이후 버튼 비활성화
        if (clickCount >= 2)
        {
            GetComponent<Button>().interactable = false; // 버튼 비활성화
            Debug.Log("강화는 두 번만 가능합니다.");
        }
    }
}

