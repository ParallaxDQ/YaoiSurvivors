using UnityEngine;

public class EnemyScript
{
    [Header("Basic Info")]
    public string enemyName = "Enemy";
    public int enemyID;
    public Sprite enemySprite;

    [Header("Stats")]
    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    public int enemyDamage;
    public int enemySpeed;

    [Header("XP")]
    public int xpDrop;

    public EnemyScript Clone()
    {
        return new EnemyScript
        {
            enemyName = this.enemyName,
            enemyID = this.enemyID,
            enemySprite = this.enemySprite,
            enemyMaxHealth = this.enemyMaxHealth,
            enemyDamage = this.enemyDamage,
            enemySpeed = this.enemySpeed,
            enemyCurrentHealth = this.enemyMaxHealth, // Start at full HP
            xpDrop = this.xpDrop,
        };
    }

    /// <summary>
    /// Calculate damage dealt to this enemy
    /// </summary>
    public int TakeDamage(int incomingDamage)
    {
        int actualDamage = incomingDamage;
        enemyCurrentHealth -= actualDamage;

        if (enemyCurrentHealth < 0)
            enemyCurrentHealth = 0;

        return actualDamage;
    }

    /// <summary>
    /// Check if enemy is defeated
    /// </summary>
    public bool IsDefeated()
    {
        return enemyCurrentHealth <= 0;
    }
}
