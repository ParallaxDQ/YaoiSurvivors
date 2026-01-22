using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float moveSpeed;

    public float attackDam;
    public float attackPerc;

    public float defense;

    public float level;
    public float experience;

    //item lists
    AbstractItem[] passiveItems;
    AbstractWeapon[] activeItems;


    //relationship vars
    public float m_relationship;
    public float j_relationship;
    public float p_relationship;

    private void Awake()
    {

    }
}
