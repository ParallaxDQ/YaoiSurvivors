using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeed;

    public float attackDam;
    public float attackPerc;

    public float defense;

    AbstractItem[] passiveItems;
    AbstractItem[] activeItems;

    private void Awake()
    {

    }
}
