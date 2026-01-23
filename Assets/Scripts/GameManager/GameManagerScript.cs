using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour //big mistake, game manager is now more of a level up screen facilitator than anything else.
{
    [SerializeField] GameObject TimerUI;
    TextMeshProUGUI TimerText;

    [SerializeField] GameObject player;
    PlayerStats playerStats;
    PlayerController playerController;

    [SerializeField] GameObject levelUpUI;
    [SerializeField] GameObject GameUI;

    [SerializeField] IncreaseStatItem[] itemList; //populate in inspector with all passive/active items
    [SerializeField] GameObject LevelUpMenu;
    LevelUpMenuScript levelUpScript;

    IncreaseStatItem[] shopArray;

    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;

    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // When returning from VN, unpause
        if (scene.name != "VisualNovelScene")
        {
            Time.timeScale = 1;
        }
    }

    
    private void Awake()
    {
     TimerText = TimerUI.GetComponent<TextMeshProUGUI>();
     StartCoroutine(AddToTimer());
     playerStats = player.GetComponent<PlayerStats>();
     playerController = player.GetComponent<PlayerController>();
     levelUpScript = LevelUpMenu.GetComponent<LevelUpMenuScript>();
    }
    
    public float timer = 0;
    IEnumerator AddToTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer += 1;
            TimerText.text = timer.ToString();
        }
    }

    public void EnterLevelUpScreen()
    {
        IncreaseStatItem[] shopArray;
        shopArray = populateShop();
        Time.timeScale = 0;
        playerController.StopAllCoroutines(); //stops all weapon cooldowns
        GameUI.SetActive(false);
        levelUpUI.SetActive(true);
        levelUpScript.ReadyShop(shopArray);
    }

    public void ExitLevelUpScreen()
    {
        Time.timeScale = 1;
        playerController.StartActiveWeapons();
        GameUI.SetActive(true);
        levelUpUI.SetActive(false);
    }
    IncreaseStatItem[] populateShop() //should return the list of the shop
    {
        IncreaseStatItem[] shopArray = { itemList[Random.Range(0, itemList.Length)], itemList[Random.Range(0, itemList.Length)], itemList[Random.Range(0, itemList.Length)]}; //random items, no validation
        return shopArray;

    }

    public void LevelUpB1Press()
    {
        passiveItemFunc(button1.GetComponent<OptionButtonScript>().containedItem);
        ExitLevelUpScreen();
    }

    public void LevelUpB2Press()
    {
        passiveItemFunc(button2.GetComponent<OptionButtonScript>().containedItem);
        ExitLevelUpScreen();
    }

    public void LevelUpB3Press()
    {
        passiveItemFunc(button3.GetComponent<OptionButtonScript>().containedItem);
        ExitLevelUpScreen();
    }

    public void passiveItemFunc(IncreaseStatItem item)
    {
        stats statToBeIncreased = (stats)item.statToBeIncreased; //have to use the brackets to explicitly cast it
        float statIncrease = item.statIncrease;
        switch (statToBeIncreased)
        {
            case stats.Damage:
                playerStats.attackDam += statIncrease;
                break;
            case stats.DamagePerc:
                playerStats.attackPerc += statIncrease;
                break;
            case stats.MoveSpeed:
                playerStats.moveSpeed += statIncrease;
                break;
            case stats.Defense:
                playerStats.defense += statIncrease;
                break;
        }
        playerStats.AddRelation(item.ma_affection,"Mark");
        playerStats.AddRelation(item.j_affection, "Jack");
        playerStats.AddRelation(item.p_affection, "Pewd");
    }

    public enum stats
    {
        Damage,
        DamagePerc,
        MoveSpeed,
        Defense
    }
}
