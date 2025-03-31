using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public WeaponStats weaponStats; // ���� ��ȭ �ɷ�ġ
    public WeaponStats currentWeaponStats; // ���� ���� �ɷ�ġ
    public Image weaponIcon; // ���� ������
    public TextMeshProUGUI weaponNameText; // ���� �̸�
    public TextMeshProUGUI weaponDescriptionText; // ���� ����

    public Image newWeaponIcon; // ���ο� ���� ������
    public TextMeshProUGUI newWeaponNameText; // ���ο� ���� �̸�
    public TextMeshProUGUI newWeaponStatsText; // ���ο� ���� �ɷ�ġ

    public GameObject[] weaponSlots; // �� ���� ���� - �����ʿ�

    private int currentUpgradeLevel = 0; // ���� ��ȭ �ܰ�

    public Inventory inventory; // �κ��丮 ����
    private Weapon equippedWeapon; // ������ ����

    public GameObject newWeaponPanel; // �� UI�� Panel

    void Start()
    {
        UpdateWeaponUI();
        UpdateNewWeaponUI(); // �� UI ������Ʈ
    }

    // ������ ���� ����
    public void EquipWeapon(WeaponStats newWeaponStats)
    {
        currentWeaponStats = newWeaponStats;
        currentUpgradeLevel = 0; // ������ ��ȭ������ �ʱ�ȭ
        newWeaponPanel.SetActive(true);

        UpdateWeaponUI(); // ���� ������ UI�� ������Ʈ
        UpdateNewWeaponUI(); // �� UI ������Ʈ
    }

    // ���� ��ȭ
    public void UpgradeWeapon()
    {
        if (currentWeaponStats != null && currentUpgradeLevel < currentWeaponStats.statUpgrades.Length)
        {
            // ��ȭ ������ ���� �ɷ�ġ ���
            currentWeaponStats = currentWeaponStats.GetStatsForUpgradeLevel(currentUpgradeLevel);
            currentUpgradeLevel++;

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

            // ������ ���� Ȱ��ȭ ���� Ȯ��
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

    public void EquipWeaponFromList(WeaponStats newWeaponStats)
    {
        EquipWeapon(newWeaponStats);
    }

    // UI ��ư Ŭ������ �����ϱ�
    public void OnEquipButtonClicked(WeaponStats weaponToEquip)
    {
        EquipWeapon(weaponToEquip); // ������ ���� ������ ����
    }

}
