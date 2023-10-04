using UnityEngine;

[CreateAssetMenu(fileName = "Balance", menuName = "Balance", order = 0)]
public class Balance : ScriptableObject
{
    [Header("Player")]
    public int minDamage;
    public int maxDamage;
    public float attackDelay;

    [Space]
    [Header("Enemy")]
    public int minEnemyHp;
    public int maxEnemyHp;

    [Space]
    [Header("Reward")]
    public int minReward;
    public int maxReward;
}
