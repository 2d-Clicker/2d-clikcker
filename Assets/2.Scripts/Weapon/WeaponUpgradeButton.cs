using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeButton : MonoBehaviour
{
    public WeaponManager weaponManager; // WeaponManager ����
    public string weaponKey;

    void Start()
    {
        // ��ư Ŭ�� �� ��ȭ �Լ� ȣ��
        GetComponent<Button>().onClick.AddListener(OnUpgradeButtonClicked);
    }

    // ��ȭ ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    private void OnUpgradeButtonClicked()
    {
        if (weaponManager != null)
        {
            // weaponKey�� �ش��ϴ� ���⸦ ��ȭ�մϴ�.
            weaponManager.UpgradeWeapon(weaponKey); // ��ȭ �Լ��� ���� Ű�� ����
        }
    }
}
