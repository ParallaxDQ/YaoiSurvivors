using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseStatItem", menuName = "Scriptable Objects/IncreaseStatItem")]
public class IncreaseStatItem : ScriptableObject
{
    public Sprite itemSprite;
    public float statIncrease;
    string itemType = "Passive"; //if item type is passive run passiveItemFunc
    public stats statToBeIncreased;
    PlayerStats playerStats;
    [SerializeField] GameObject player;
    public float m_affection;
    public float j_affection;
    public float p_affection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }



    public enum stats
    {
        Damage,
        DamagePerc,
        MoveSpeed,
        Defense
    }
}
