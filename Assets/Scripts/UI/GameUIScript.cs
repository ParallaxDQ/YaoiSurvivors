using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerStats playerStats;

    [SerializeField] GameObject healthBar;
    Image healthImage;

    [SerializeField] GameObject expBar;
    Image expImage;
    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        healthImage = healthBar.GetComponent<Image>();
        expImage = expBar.GetComponent<Image>();
    }
    
    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = playerStats.curHealth / playerStats.maxHealth;
    }
}
