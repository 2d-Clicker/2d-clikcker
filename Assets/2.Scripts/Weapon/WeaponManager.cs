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

    public WeaponStats weaponStats; // ���� ��ȭ �ɷ�ġ
    public Image weaponIcon; // ���� ������
    public TextMeshProUGUI weaponNameText; // ���� �̸�
    public TextMeshProUGUI weaponDescriptionText; // ���� ����

    public Image newWeaponIcon; // ���ο� ���� ������
    public TextMeshProUGUI newWeaponNameText; // ���ο� ���� �̸�
    public TextMeshProUGUI newWeaponStatsText; // ���ο� ���� �ɷ�ġ

    private int currentUpgradeLevel = 0; // ���� ��ȭ �ܰ�

    public GoldManager goldManager; // goldManager ����
    public Inventory inventory; // inventory ����
    private Weapon equippedWeapon; // ������ ����
    private WeaponStats currentWeaponStats; // ���� ������ ���� ����

    // ��ȭ �ݾ� ����
    private Dictionary<string, int> weaponUpgradeCosts = new Dictionary<string, int>();

    void Start()
    {
        InitializeWeapon(); // ���� ���� �� ���� �ʱ�ȭ
        UpdateWeaponUI(); // UI ������Ʈ
        UpdateNewWeaponUI(); 

        InitializeWeaponUpgradeCosts();  // ���⺰ ��ȭ �ݾ� �ʱ�ȭ
    }

    // ���⺰ ��ȭ �ݾ� ����
    private void InitializeWeaponUpgradeCosts()
    {
        weaponUpgradeCosts.Add("KnifeGamja", 5); // ����� ��ȭ ���
        weaponUpgradeCosts.Add("KnifeShort", 150);
        weaponUpgradeCosts.Add("KnifeBread", 500);
        weaponUpgradeCosts.Add("KnifeKitchen", 3000);
        weaponUpgradeCosts.Add("KnifeChef", 10000);
    }

    // ���� ���� �� ���� �ʱ�ȭ
    public void InitializeWeapon()
    {
        // ������ ���۵Ǹ� �⺻ �ɷ�ġ�� �ʱ�ȭ�մϴ�.
        currentUpgradeLevel = 0; // ��ȭ ���� �ʱ�ȭ
        currentWeaponStats = weaponStats; // �⺻ �ɷ�ġ
        UpdateWeaponUI(); // UI ������Ʈ
    }

    // ������ ���� ����
    public void EquipWeapon(WeaponStats newWeaponStats)
    {
        // �̹� ������ ���������� üũ
        if (IsWeaponAlreadyBought(newWeaponStats.weaponName))
        {
            Debug.Log("�̹� �� ���⸦ �����߽��ϴ�.");
            return;
        }

        // ���� ����
        if (currentWeaponStats != null && currentWeaponStats.weaponName == newWeaponStats.weaponName)
        {
            // ���� ������ ������, ��ȭ ���� ����
            currentWeaponStats = newWeaponStats;
        }
        else
        {
            // ���ο� ������, ��ȭ ���� �ʱ�ȭ
            currentWeaponStats = newWeaponStats;
            currentUpgradeLevel = 0; // ��ȭ ���� �ʱ�ȭ
        }

        // �÷��̾� ���� ������Ʈ
        PlayerStats.Instance.playerData.EquipWeapon(currentWeaponStats);

        // ������ ������ ���� ��Ȱ��ȭ
        DeactivateAllPanels();

        // ���ο� ���� ����
        if (newWeaponStats.weaponName == "����Į")
        {
            knifeGamja.SetActive(true);
        }
        else if (newWeaponStats.weaponName == "ª��Į")
        {
            knifeShort.SetActive(true);
        }
        else if (newWeaponStats.weaponName == "�� Į")
        {
            knifeBread.SetActive(true);
        }
        else if (newWeaponStats.weaponName == "�� Į")
        {
            knifeKitchen.SetActive(true);
        }
        else if (newWeaponStats.weaponName == "�߽ĵ�")
        {
            knifeChef.SetActive(true);
        }

        UpdateWeaponUI(); // UI ������Ʈ
    }

    public void UpgradeWeapon(string weaponName)
    {
        if (currentWeaponStats != null && currentUpgradeLevel < currentWeaponStats.statUpgrades.Length)
        {
            // ���� ������ ������ �̸��� �޾Ƽ� �ش� ������ ��ȭ ����� Ȯ��
            if (weaponUpgradeCosts.ContainsKey(weaponName))
            {
                int upgradeCost = weaponUpgradeCosts[weaponName];

                // ��ȭ �ݾ��� ������� üũ�ϰ�, ��� �Ҹ�
                if (goldManager.SpendGold(upgradeCost))
                {
                    // ��ȭ ������ ���� �ɷ�ġ ���
                    currentWeaponStats = currentWeaponStats.GetStatsForUpgradeLevel(currentUpgradeLevel, currentWeaponStats);
                    currentUpgradeLevel++; // ��ȭ �ܰ� ����

                    UpdateWeaponUI(); // ��ȭ�� �ɷ�ġ�� ȭ�鿡 ������Ʈ
                }
                else
                {
                    Debug.Log("��尡 �����մϴ�.");
                }
            }
            else
            {
                Debug.Log("�ش� ������ ��ȭ ����� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            // ��ȭ�� �Ұ����� ���
            Debug.Log("��ȭ�� �Ұ����մϴ�.");
        }
    }

    // ���� UI ������Ʈ
    private void UpdateWeaponUI()
    {
        if (currentWeaponStats != null)
        {
            // ���� UI ������Ʈ
            weaponNameText.text = currentWeaponStats.weaponName;
            weaponDescriptionText.text = currentWeaponStats.itemDescription;

            // ���� UI�� ������ ������Ʈ
            if (currentWeaponStats.itemIcon != null)
            {
                weaponIcon.sprite = currentWeaponStats.itemIcon;
            }

            // ������ ���� UI ������Ʈ: ����, ���ݷ�, ġ��Ÿ Ȯ��
            newWeaponNameText.text = currentWeaponStats.weaponName + " (Lv." + currentUpgradeLevel + ")";
            newWeaponStatsText.text = "���ݷ�: " + currentWeaponStats.baseDamage + "\n\n" +
                                      "ġ��Ÿ Ȯ��: " + (currentWeaponStats.baseCritChance * 100) + "%";

            // ������ ���� ������ ������Ʈ
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
            // �� UI ������Ʈ: ���� �̸�, �ɷ�ġ
            newWeaponNameText.text = currentWeaponStats.weaponName + " (Lv." + currentUpgradeLevel + ")";
            newWeaponStatsText.text = "���ݷ�: " + currentWeaponStats.baseDamage + "\n\n" +
                                      "ġ��Ÿ Ȯ��: " + (currentWeaponStats.baseCritChance * 100) + "%";
            newWeaponIcon.sprite = currentWeaponStats.itemIcon; // ������ ������Ʈ
        }
        else
        {
            // ���� ������ ������ �ؽ�Ʈ�� "No weapon equipped" ǥ��
            newWeaponNameText.text = "No weapon equipped.";
            newWeaponStatsText.text = "";
            newWeaponIcon.sprite = null; // ������ ����
        }
    }

    // UI ��ư Ŭ������ �����ϱ�
    public void OnEquipButtonClicked(WeaponStats weaponToEquip)
    {
        EquipWeapon(weaponToEquip); // ������ ���� ������ ����
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
            case "����Į":
                return PlayerStats.Instance.playerData.hasBoughtKnifeGamja;
            case "ª��Į":
                return PlayerStats.Instance.playerData.hasBoughtKnifeShort;
            case "�� Į":
                return PlayerStats.Instance.playerData.hasBoughtKnifeBread;
            case "�� Į":
                return PlayerStats.Instance.playerData.hasBoughtKnifeKitchen;
            case "�߽ĵ�":
                return PlayerStats.Instance.playerData.hasBoughtKnifeChef;
            default:
                return false;
        }
    }
}
