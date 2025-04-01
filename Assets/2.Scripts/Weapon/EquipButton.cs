using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    public WeaponStats weaponStats; // �� ��ư�� �ش��ϴ� ���� ����
    public WeaponManager weaponManager; // WeaponManager ��ũ��Ʈ

    void Start()
    {
        // ��ư�� Ŭ�� ������ �߰�
        GetComponent<Button>().onClick.AddListener(OnEquipButtonClicked);
    }

    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    private void OnEquipButtonClicked()
    {
        weaponManager.EquipWeapon(weaponStats);  // �ش� ���� ����
    }
}
