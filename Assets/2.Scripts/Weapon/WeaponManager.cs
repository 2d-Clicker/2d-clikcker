using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public WeaponStats weaponStats; // 무기 강화 능력치
    public WeaponStats currentWeaponStats; // 현재 무기 능력치
    public Image weaponIcon; // 무기 아이콘
    public TextMeshProUGUI weaponNameText; // 무기 이름
    public TextMeshProUGUI weaponDescriptionText; // 무기 설명

    public Image newWeaponIcon; // 새로운 무기 아이콘
    public TextMeshProUGUI newWeaponNameText; // 새로운 무기 이름
    public TextMeshProUGUI newWeaponStatsText; // 새로운 무기 능력치

    public GameObject[] weaponSlots; // 각 무기 슬롯 - 수정필요

    private int currentUpgradeLevel = 0; // 현재 강화 단계

    public Inventory inventory; // 인벤토리 참조
    private Weapon equippedWeapon; // 장착된 무기

    public GameObject newWeaponPanel; // 새 UI의 Panel

    void Start()
    {
        UpdateWeaponUI();
        UpdateNewWeaponUI(); // 새 UI 업데이트
    }

    // 장착할 무기 선택
    public void EquipWeapon(WeaponStats newWeaponStats)
    {
        currentWeaponStats = newWeaponStats;
        currentUpgradeLevel = 0; // 장착시 강화레벨을 초기화
        newWeaponPanel.SetActive(true);

        UpdateWeaponUI(); // 무기 정보를 UI에 업데이트
        UpdateNewWeaponUI(); // 새 UI 업데이트
    }

    // 무기 강화
    public void UpgradeWeapon()
    {
        if (currentWeaponStats != null && currentUpgradeLevel < currentWeaponStats.statUpgrades.Length)
        {
            // 강화 레벨에 따른 능력치 계산
            currentWeaponStats = currentWeaponStats.GetStatsForUpgradeLevel(currentUpgradeLevel);
            currentUpgradeLevel++;

            UpdateWeaponUI(); // 강화된 능력치를 화면에 업데이트
        }
        else
        {
            // 강화가 불가능한 경우
            Debug.Log("강화가 불가능합니다.");
        }
    }

    // 무기 UI 업데이트
    private void UpdateWeaponUI()
    {
        if (currentWeaponStats != null)
        {
            // 도구 UI 업데이트
            weaponNameText.text = currentWeaponStats.weaponName;
            weaponDescriptionText.text = currentWeaponStats.itemDescription;

            // 도구 UI의 아이콘 업데이트
            if (currentWeaponStats.itemIcon != null)
            {
                weaponIcon.sprite = currentWeaponStats.itemIcon;
            }

            // 장착된 무기 UI 업데이트: 레벨, 공격력, 치명타 확률
            newWeaponNameText.text = currentWeaponStats.weaponName + " (Lv." + currentUpgradeLevel + ")";
            newWeaponStatsText.text = "공격력: " + currentWeaponStats.baseDamage + "\n\n" +
                                      "치명타 확률: " + (currentWeaponStats.baseCritChance * 100) + "%";

            // 장착된 무기 아이콘 업데이트
            if (currentWeaponStats.itemIcon != null)
            {
                newWeaponIcon.sprite = currentWeaponStats.itemIcon;
            }

            // 장착된 무기 활성화 여부 확인
            newWeaponPanel.SetActive(true);
        }
        else
        {
            newWeaponPanel.SetActive(false);
        }
    }

    private void UpdateNewWeaponUI()
    {
        if (currentWeaponStats != null)
        {
            // 새 UI 업데이트: 무기 이름, 능력치
            newWeaponNameText.text = currentWeaponStats.weaponName + " (Lv." + currentUpgradeLevel + ")";
            newWeaponStatsText.text = "공격력: " + currentWeaponStats.baseDamage + "\n\n" +
                                      "치명타 확률: " + (currentWeaponStats.baseCritChance * 100) + "%";
            newWeaponIcon.sprite = currentWeaponStats.itemIcon; // 아이콘 업데이트
        }
        else
        {
            // 무기 정보가 없으면 텍스트로 "No weapon equipped" 표시
            newWeaponNameText.text = "No weapon equipped.";
            newWeaponStatsText.text = "";
            newWeaponIcon.sprite = null; // 아이콘 비우기
        }
    }

    public void EquipWeaponFromList(WeaponStats newWeaponStats)
    {
        EquipWeapon(newWeaponStats);
    }

    // UI 버튼 클릭으로 장착하기
    public void OnEquipButtonClicked(WeaponStats weaponToEquip)
    {
        EquipWeapon(weaponToEquip); // 장착할 무기 정보를 전달
    }

}
