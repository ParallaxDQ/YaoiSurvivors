using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyScript enemyData;
    private Transform player;
    private float lastDamageTime = -999f;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private bool isInitialized = false;
    private bool isDead = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (enemyData != null)
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        if (isInitialized) return;

        currentHealth = enemyData.enemyMaxHealth;

        if (spriteRenderer != null && enemyData.enemySprite != null)
        {
            spriteRenderer.sprite = enemyData.enemySprite;
        }

        isInitialized = true;
    }

    void Update()
    {
        if (player != null && enemyData != null && !isDead)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * enemyData.enemySpeed * Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Player") && enemyData != null)
        {
            if (Time.time >= lastDamageTime + enemyData.enemyAttackCooldown)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(enemyData.enemyDamage);
                    lastDamageTime = Time.time;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Weapon"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log($"{enemyData.enemyName} took {damage} damage! Health: {currentHealth}/{enemyData.enemyMaxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log($"{enemyData.enemyName} died!");

        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null && enemyData != null)
        {
            playerStats.AddEXP(enemyData.xpDrop);
        }

        Destroy(gameObject);
    }
}