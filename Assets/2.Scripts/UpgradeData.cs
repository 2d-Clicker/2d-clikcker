using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Data", menuName = "Upgrade System/Upgrade Data")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;      // 업그레이드 이름 (치명타, 자동 공격, 골드 획득)
    public int maxLevel;            // 최대 레벨
    public float baseValue;         // 기본 값 (예: 치명타 10%)
    public float increasePerLevel;  // 레벨당 증가량 (예: +2%)
    public int baseCost;            // 기본 업그레이드 비용
    public float costMultiplier;    // 비용 증가 배율

 
}
