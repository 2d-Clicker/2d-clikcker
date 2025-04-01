using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeButton : MonoBehaviour
{
    public WeaponManager weaponManager; // WeaponManager 참조
    public string weaponKey;

    void Start()
    {
        // 버튼 클릭 시 강화 함수 호출
        GetComponent<Button>().onClick.AddListener(OnUpgradeButtonClicked);
    }

    // 강화 버튼 클릭 시 호출되는 함수
    private void OnUpgradeButtonClicked()
    {
        if (weaponManager != null)
        {
            // weaponKey에 해당하는 무기를 강화합니다.
            weaponManager.UpgradeWeapon(weaponKey); // 강화 함수에 무기 키를 전달
        }
    }
}
