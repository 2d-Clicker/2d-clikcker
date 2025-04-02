using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public GameObject knifeGamja;
    public GameObject knifeShort;
    public GameObject knifeBread;
    public GameObject knifeKitchen;
    public GameObject knifeChef;

    public WeaponStats weaponStats; // 무기 강화 능력치
    public Image weaponIcon; // 무기 아이콘
    public TextMeshProUGUI weaponNameText; // 무기 이름
    public TextMeshProUGUI weaponDescriptionText; // 무기 설명

    public Image newWeaponIcon; // 새로운 무기 아이콘
    public TextMeshProUGUI newWeaponNameText; // 새로운 무기 이름
    public TextMeshProUGUI newWeaponStatsText; // 새로운 무기 능력치

    private int currentUpgradeLevel = 0; // 현재 강화 단계

    public GoldManager goldManager; // goldManager 참조
    public Inventory inventory; // inventory 참조
    private Weapon equippedWeapon; // 장착된 무기
    private WeaponStats currentWeaponStats; // 현재 장착된 무기 정보

    // 강화 금액 설정
    private Dictionary<string, int> weaponUpgradeCosts = new Dictionary<string, int>();

    void Start()
    {
        InitializeWeapon(); // 게임 시작 시 무기 초기화
        UpdateWeaponUI(); // UI 업데이트
        UpdateNewWeaponUI(); 

        InitializeWeaponUpgradeCosts();  // 무기별 강화 금액 초기화
    }

    // 무기별 강화 금액 설정
    private void InitializeWeaponUpgradeCosts()
    {
        weaponUpgradeCosts.Add("KnifeGamja", 5); // 무기당 강화 비용
        weaponUpgradeCosts.Add("KnifeShort", 150);
        weaponUpgradeCosts.Add("KnifeBread", 500);
        weaponUpgradeCosts.Add("KnifeKitchen", 3000);
        weaponUpgradeCosts.Add("KnifeChef", 10000);
    }

    // 게임 시작 시 무기 초기화
    public void InitializeWeapon()
    {
        // 게임이 시작되면 기본 능력치로 초기화합니다.
        currentUpgradeLevel = 0; // 강화 레벨 초기화
        currentWeaponStats = weaponStats; // 기본 능력치
        UpdateWeaponUI(); // UI 업데이트
    }

    // 장착할 무기 선택
    public void EquipWeapon(WeaponStats newWeaponStats)
    {
        // 이미 구매한 아이템인지 체크
        if (IsWeaponAlreadyBought(newWeaponStats.weaponName))
        {
            Debug.Log("이미 이 무기를 구매했습니다.");
            return;
        }

        // 무기 장착
        if (currentWeaponStats != null && currentWeaponStats.weaponName == newWeaponStats.weaponName)
        {
            // 기존 장착된 무기라면, 강화 레벨 유지
            currentWeaponStats = newWeaponStats;
        }
        else
        {
            // 새로운 무기라면, 강화 레벨 초기화
            currentWeaponStats = newWeaponStats;
            currentUpgradeLevel = 0; // 강화 상태 초기화
        }

        // 플레이어 스텟 업데이트
        PlayerStats.Instance.playerData.EquipWeapon(currentWeaponStats);

        // 기존에 장착된 무기 비활성화
        DeactivateAllPanels();

        // 새로운 무기 장착
        if (newWeaponStats.weaponName == "감자칼")
        {
            knifeGamja.SetActive(true);
        }
        else if (newWeaponStats.weaponName == "짧은칼")
        {
            knifeShort.SetActive(true);
        }
        else if (newWeaponStats.weaponName == "빵 칼")
        {
            knifeBread.SetActive(true);
        }
        else if (newWeaponStats.weaponName == "식 칼")
        {
            knifeKitchen.SetActive(true);
        }
        else if (newWeaponStats.weaponName == "중식도")
        {
            knifeChef.SetActive(true);
        }

        UpdateWeaponUI(); // UI 업데이트
    }

    public void UpgradeWeapon(string weaponName)
    {
        if (currentWeaponStats != null && currentUpgradeLevel < currentWeaponStats.statUpgrades.Length)
        {
            // 현재 장착된 무기의 이름을 받아서 해당 무기의 강화 비용을 확인
            if (weaponUpgradeCosts.ContainsKey(weaponName))
            {
                int upgradeCost = weaponUpgradeCosts[weaponName];

                // 강화 금액이 충분한지 체크하고, 골드 소모
                if (goldManager.SpendGold(upgradeCost))
                {
                    // 강화 레벨에 따른 능력치 계산
                    currentWeaponStats = currentWeaponStats.GetStatsForUpgradeLevel(currentUpgradeLevel, currentWeaponStats);
                    currentUpgradeLevel++; // 강화 단계 증가

                    UpdateWeaponUI(); // 강화된 능력치를 화면에 업데이트
                }
                else
                {
                    Debug.Log("골드가 부족합니다.");
                }
            }
            else
            {
                Debug.Log("해당 무기의 강화 비용을 찾을 수 없습니다.");
            }
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

    // UI 버튼 클릭으로 장착하기
    public void OnEquipButtonClicked(WeaponStats weaponToEquip)
    {
        EquipWeapon(weaponToEquip); // 장착할 무기 정보를 전달
    }

    private void DeactivateAllPanels()
    {
        knifeGamja.SetActive(false);
        knifeShort.SetActive(false);
        knifeBread.SetActive(false);
        knifeKitchen.SetActive(false);
        knifeChef.SetActive(false);
    }

    private bool IsWeaponAlreadyBought(string weaponName)
    {
        switch (weaponName)
        {
            case "감자칼":
                return PlayerStats.Instance.playerData.hasBoughtKnifeGamja;
            case "짧은칼":
                return PlayerStats.Instance.playerData.hasBoughtKnifeShort;
            case "빵 칼":
                return PlayerStats.Instance.playerData.hasBoughtKnifeBread;
            case "식 칼":
                return PlayerStats.Instance.playerData.hasBoughtKnifeKitchen;
            case "중식도":
                return PlayerStats.Instance.playerData.hasBoughtKnifeChef;
            default:
                return false;
        }
    }
}
