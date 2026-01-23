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

    [SerializeField] GameObject levelUpUI;

    private void Awake()
    {
     TimerText = TimerUI.GetComponent<TextMeshProUGUI>();
     StartCoroutine(AddToTimer());
     playerStats = player.GetComponent<PlayerStats>();
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
        levelUpUI.SetActive(true);
    }

    public void ExitLevelUpScreen()
    {
        Time.timeScale = 1;
        levelUpUI.SetActive(false);
    }
}
