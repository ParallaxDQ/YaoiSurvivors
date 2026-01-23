using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyScript enemyData;
    private Transform player;
    private float lastDamageTime = -999f;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private bool isInitialized = false;

    void Start()
    {
        // Find the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    
        // Get sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    
        // Initialize if data is already assigned
        if (enemyData != null)
        {
            Initialize();
        }
    }

    // Call this after assigning enemyData
    public void Initialize()
    {
        if (isInitialized) return;
        
        // Initialize health
        currentHealth = enemyData.enemyMaxHealth;
        
        // Set up sprite
        if (spriteRenderer != null && enemyData.enemySprite != null)
        {
            spriteRenderer.sprite = enemyData.enemySprite;
        }
        
        isInitialized = true;
    }

    void Update()
    {
        // Move towards player
        if (player != null && enemyData != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * enemyData.enemySpeed * Time.deltaTime;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Check if touching player
        if (collision.gameObject.CompareTag("Player") && enemyData != null)
        {
            // Check cooldown - use enemyData.attackCooldown for individual cooldowns
            if (Time.time >= lastDamageTime + enemyData.enemyAttackCooldown)
            {

                PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(enemyData.enemyDamage);
                    lastDamageTime = Time.time;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}