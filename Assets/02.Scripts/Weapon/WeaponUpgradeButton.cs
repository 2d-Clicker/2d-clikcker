using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeButton : MonoBehaviour
{
    public WeaponManager weaponManager; // WeaponManager ����
    public string weaponKey;
    private int clickCount = 0; // Ŭ�� Ƚ�� ����

    void Start()
    {
        // ��ư Ŭ�� �� ��ȭ �Լ� ȣ��
        GetComponent<Button>().onClick.AddListener(OnUpgradeButtonClicked);
    }

    // ��ȭ ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    private void OnUpgradeButtonClicked()
    {
        if (clickCount >= 2)
        {
            // �� �� Ŭ�� ���Ŀ��� �� �̻� Ŭ������ �ʵ��� ��
            return;
        }

        clickCount++; // Ŭ�� Ƚ�� ����

        if (weaponManager != null)
        {
            // weaponKey�� �ش��ϴ� ���⸦ ��ȭ�մϴ�.
            weaponManager.UpgradeWeapon(weaponKey); // ��ȭ �Լ��� ���� Ű�� ����
        }

        // �� �� Ŭ�� ���� ��ư ��Ȱ��ȭ
        if (clickCount >= 2)
        {
            GetComponent<Button>().interactable = false; // ��ư ��Ȱ��ȭ
            Debug.Log("��ȭ�� �� ���� �����մϴ�.");
        }
    }
}

