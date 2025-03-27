using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Upgrade System/Upgrade Data")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;      // 업그레이드 이름
    public int maxLevel;            // 최대 레벨
    public float baseValue;         // 기본 능력치 값
    public float increasePerLevel;  // 레벨당 증가량
    public int baseCost;            // 기본 업그레이드 비용
    public float costMultiplier;    // 비용 증가 배율

    // 현재 레벨에 따른 업그레이드 효과 계산
    public float GetUpgradeValue(int level)
    {
        return baseValue + (increasePerLevel * level);
    }

    // 현재 레벨에 따른 업그레이드 비용 계산
    public int GetUpgradeCost(int level)
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, level));
    }
}
