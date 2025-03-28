using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData = new PlayerData();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpgradeCriticalDamage()
    {
        playerData.criticalDamage += 10;
    }

    public void UpgradeAutoAttack()
    {
        playerData.autoAttack += 0.3f;
    }

    public void UpgradeGoldBonus()
    {
        playerData.goldBonus += 1;
    }
}
