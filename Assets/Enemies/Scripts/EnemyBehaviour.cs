using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private EnemyScript enemyData;
    private Transform player;
    private Rigidbody2D rb;
    private float lastDamageTime;

    public void Initialise(EnemyScript enemyScript)
    {
        enemyData = enemyScript;

        GetComponent<SpriteRenderer>().sprite = enemyData.enemySprite;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        lastDamageTime = -1f;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * enemyData.enemySpeed;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > lastDamageTime + 1f)
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
}
