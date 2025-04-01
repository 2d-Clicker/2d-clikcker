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

    public Inventory inventory; // �κ��丮 ����
    private Weapon equippedWeapon; // ������ ����
    private WeaponStats currentWeaponStats; // ���� ������ ���� ����

    void Start()
    {
        UpdateWeaponUI();
        UpdateNewWeaponUI(); // �� UI ������Ʈ
        // ��� �г� ��Ȱ��ȭ
        DeactivateAllPanels();
    }

    // ������ ���� ����
    public void EquipWeapon(WeaponStats newWeaponStats)
    {
        // ���ο� ���⸦ ������ ��, ������ �ɷ�ġ�� ������ ��ȭ ���¸� ����
        if (currentWeaponStats != null && currentWeaponStats.weaponName == newWeaponStats.weaponName)
        {
            // �̹� ������ ������, ��ȭ ���� ����
            currentWeaponStats = newWeaponStats;
        }
        else
        {
            // ���ο� ������, ��ȭ ���� �ʱ�ȭ
            currentWeaponStats = newWeaponStats;
            currentUpgradeLevel = 0; // ��ȭ ���� �ʱ�ȭ
        }

        // ��� �г� ��Ȱ��ȭ
        DeactivateAllPanels();

        // ���õ� ���⿡ �´� �гθ� Ȱ��ȭ
        if (currentWeaponStats.weaponName == "����Į")
        {
            knifeGamja.SetActive(true);
        }
        else if (currentWeaponStats.weaponName == "ª��Į")
        {
            knifeShort.SetActive(true);
        }
        else if (currentWeaponStats.weaponName == "�� Į")
        {
            knifeBread.SetActive(true);
        }
        else if (currentWeaponStats.weaponName == "�� Į")
        {
            knifeKitchen.SetActive(true);
        }
        else if (currentWeaponStats.weaponName == "�߽ĵ�")
        {
            knifeChef.SetActive(true);
        }

        UpdateWeaponUI(); // UI ������Ʈ
    }

    // ���� ��ȭ
    public void UpgradeWeapon()
    {
        if (currentWeaponStats != null && currentUpgradeLevel < currentWeaponStats.statUpgrades.Length)
        {
            // ��ȭ ������ ���� �ɷ�ġ ���
            currentWeaponStats = currentWeaponStats.GetStatsForUpgradeLevel(currentUpgradeLevel, currentWeaponStats);
            currentUpgradeLevel++; // ��ȭ �ܰ� ����

            UpdateWeaponUI(); // ��ȭ�� �ɷ�ġ�� ȭ�鿡 ������Ʈ
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
}
