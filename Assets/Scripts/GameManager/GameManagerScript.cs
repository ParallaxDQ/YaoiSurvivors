using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject TimerUI;
    TextMeshProUGUI TimerText;

    [SerializeField] GameObject player;
    PlayerStats playerStats;
    PlayerController playerController;

    [SerializeField] GameObject levelUpUI;
    [SerializeField] GameObject GameUI;

    private void Awake()
    {
     TimerText = TimerUI.GetComponent<TextMeshProUGUI>();
     StartCoroutine(AddToTimer());
     playerStats = player.GetComponent<PlayerStats>();
     playerController = player.GetComponent<PlayerController>();
        EnterLevelUpScreen();
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
        Time.timeScale = 0;
        playerController.StopAllCoroutines(); //stops all weapon cooldowns
        GameUI.SetActive(false);
        levelUpUI.SetActive(true);
    }

    public void ExitLevelUpScreen()
    {
        playerController.StartActiveWeapons();
        GameUI.SetActive(true);
        levelUpUI.SetActive(false);
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
