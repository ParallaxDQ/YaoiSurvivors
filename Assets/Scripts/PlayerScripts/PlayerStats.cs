using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeed;

    public float attackDam;
    public float attackPerc;

    public float defense;

    AbstractItem[] passiveItems;
    AbstractItem[] activeItems;

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
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

    }

    private void Awake()
    {

    }
}
