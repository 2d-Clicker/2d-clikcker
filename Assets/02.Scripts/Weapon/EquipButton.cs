using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    public WeaponStats weaponStats; // 이 버튼에 해당하는 무기 정보
    public WeaponManager weaponManager; // WeaponManager 스크립트

    void Start()
    {
        // 버튼에 클릭 리스너 추가
        GetComponent<Button>().onClick.AddListener(OnEquipButtonClicked);
    }

    // 장착 버튼 클릭 시 호출되는 함수
    private void OnEquipButtonClicked()
    {
        weaponManager.EquipWeapon(weaponStats);  // 해당 무기 장착
    }
}
