using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseStatItem", menuName = "Scriptable Objects/IncreaseStatItem")]
public class IncreaseStatItem : ScriptableObject
{
    [SerializeField] Sprite itemSprite;
    [SerializeField] float statIncrease;
    string itemType = "Passive"; //if item type is passive run passiveItemFunc
    [SerializeField]stats statToBeIncreased;
    PlayerStats player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public IncreaseStatItem(PlayerStats player)
    {
        this.player = player;
    }


    public void passiveItemFunc()
    {
        switch (statToBeIncreased)
        {
            case stats.Damage:
                player.attackDam += statIncrease;
                break;
            case stats.DamagePerc:
                player.attackPerc += statIncrease;
                break;
            case stats.MoveSpeed:
                player.moveSpeed += statIncrease;
                break;
            case stats.Defense:
                player.defense += statIncrease;
                break;
        }
    }

    enum stats
    {
        Damage,
        DamagePerc,
        MoveSpeed,
        Defense
    }
}
