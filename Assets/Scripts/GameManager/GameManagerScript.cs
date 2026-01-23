using System.Collections;
using UnityEngine;
using TMPro;

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
    private void Awake()
    {
     TimerText = TimerUI.GetComponent<TextMeshProUGUI>();
     StartCoroutine(AddToTimer());
     playerStats = player.GetComponent<PlayerStats>();
     playerController = player.GetComponent<PlayerController>();
     levelUpScript = LevelUpMenu.GetComponent<LevelUpMenuScript>();
        EnterLevelUpScreen(); //remove before end
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
        shopArray = populateShop();
        Time.timeScale = 0;
        playerController.StopAllCoroutines(); //stops all weapon cooldowns
        GameUI.SetActive(false);
        levelUpUI.SetActive(true);
        levelUpScript.ReadyShop(shopArray);
    }

    public void ExitLevelUpScreen()
    {
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
        passiveItemFunc(shopArray[0]);
    }

    public void LevelUpB2Press()
    {
        passiveItemFunc(shopArray[1]);
    }

    public void LevelUpB3Press()
    {
        passiveItemFunc(shopArray[2]);
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
    }

    public enum stats
    {
        Damage,
        DamagePerc,
        MoveSpeed,
        Defense
    }
}
