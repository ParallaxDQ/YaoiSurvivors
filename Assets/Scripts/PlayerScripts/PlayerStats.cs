using System.Collections;
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
        //reset stats
        experience = 0;
        level = 1;
        defense = 0;
        attackPerc = 0;
        attackDam = 0;
        moveSpeed = 100;

        //reset relationships
        m_relationship = 0;
        j_relationship = 0;
        p_relationship = 0;
    }

    private void AddEXP(float expGain)
    {
        experience += expGain;
        if (experience>100)
        {
            experience -= 100;
            //Trigger the LevelUp menu
        }
    }

    private void AddRelation(int relationGain,string name) //prob better to use enum for the name, but alas
    {
        switch (name)
        {
            case "Mark":
                m_relationship += relationGain;
                if (m_relationship < 10) //relation maxes at 10
                {
                    m_relationship = 10;
                }
                break;

            case "Jack":
                j_relationship += relationGain;
                if (j_relationship < 10) //relation maxes at 10
                {
                    j_relationship = 10;
                }
                break;

            case "Pewd":
                p_relationship += relationGain;
                if (p_relationship < 10) //relation maxes at 10
                {
                    p_relationship = 10;
                }
                break;
        }
    }
}
