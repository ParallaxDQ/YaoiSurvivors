using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;

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

    [SerializeField] GameObject gameManager;
    GameManagerScript GMS;

    [SerializeField] GameObject expBar;
    Image expImage;

    private bool[] relationshipEventsCompleted = new bool[3];

    private void Awake()
    {
        //reset stats
        experience = 0;
        level = 1;
        defense = 0;
        attackPerc = 0;
        attackDam = 0;
        moveSpeed = 100;

        maxHealth = 10;
        curHealth = maxHealth;

        //reset relationships
        m_relationship = 0;
        j_relationship = 0;
        p_relationship = 0;

        GMS = gameManager.GetComponent<GameManagerScript>();

        if (expBar != null)
        {
            expImage = expBar.GetComponent<Image>();
        }
    }

    public void AddEXP(float expGain)
    {
        experience += expGain;

        if (expImage != null)
        {
            expImage.fillAmount = experience / 100;
        }

        if (experience >= 100)
        {
            experience -= 100;
            GMS.EnterLevelUpScreen();
        }
    }

    public void AddRelation(int relationGain, string name)
    {
        switch (name)
        {
            case "Mark":
                m_relationship += relationGain;
                if (m_relationship >= 10)
                {
                    m_relationship = 10;
                    CheckRelationshipEvent("Mark", 0);
                }
                break;

            case "Jack":
                j_relationship += relationGain;
                if (j_relationship >= 10)
                {
                    j_relationship = 10;
                    CheckRelationshipEvent("Jack", 1);
                }
                break;

            case "Pewd":
                p_relationship += relationGain;
                if (p_relationship >= 10)
                {
                    p_relationship = 10;
                    CheckRelationshipEvent("Pewd", 2);
                }
                break;
        }
    }

    void CheckRelationshipEvent(string characterName, int index)
    {
        if (!relationshipEventsCompleted[index] && PlayerPrefs.GetInt($"VN_Completed_{characterName}", 0) == 0)
        {
            relationshipEventsCompleted[index] = true;
            TriggerVisualNovel(characterName);
        }
    }

    void TriggerVisualNovel(string characterName)
    {
        PlayerPrefs.SetString("VN_Character", characterName);
        PlayerPrefs.SetString("VN_ReturnScene", SceneManager.GetActiveScene().name);
        Time.timeScale = 0;
        SceneManager.LoadScene("VisualNovelScene", LoadSceneMode.Additive);
    }

    public string StatStringGen()
    {
        return "Level:\t" + level.ToString() + "\n" + "Max health:\t" + maxHealth.ToString() + "\n" + "Damage:\t" + attackDam.ToString() + "\n" + "Dam Percent:\t" + attackPerc.ToString() + "\n" + "Defense:\t" + defense.ToString() + "\n";
    }
}