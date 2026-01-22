using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Game/Enemy")]
public class EnemySO : ScriptableObject
{
    [Header("Basic Info")]
    [Tooltip("Name displayed in combat")]
    public string enemyName = "Enemy";
    [Tooltip("EnemyID")]
    public int enemyID;
    
    [Tooltip("Attack Cooldown")]
    public float enemyAttackCooldown = 1f;


    [Header("Stats")]
    [Tooltip("Max enemy health")]
    public int maxHealth;
    [Tooltip("Enemy damage to player")]
    public int Damage;
    [Tooltip("Enemy speed")]
    public int Speed;
    [Tooltip("Levels of XP to drop (1, 2 or 3)")]
    public int xpDrop;

    [Header("Visual")]
    public Sprite enemySprite;
    [Tooltip("Animator with this enemy's animations")]
    public AnimatorOverrideController animatorController;
    public float displayScale = 5f;

    /// <summary>
    /// Convert this ScriptableObject to runtime EnemyData
    /// </summary>
    public EnemyScript ToEnemyData()
    {
        return new EnemyScript
        {
            enemyName = this.enemyName,
            enemyID = this.enemyID,
            enemySprite = this.enemySprite,
            enemyMaxHealth = this.maxHealth,
            enemyDamage = this.Damage,
            enemySpeed = this.Speed,
            enemyCurrentHealth = this.maxHealth, // Start at full HP
            xpDrop = this.xpDrop,
            enemyAttackCooldown = this.enemyAttackCooldown,
        };
    }
}


