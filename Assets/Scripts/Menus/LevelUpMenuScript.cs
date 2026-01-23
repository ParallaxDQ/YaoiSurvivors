using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenuScript : MonoBehaviour
{
    [Header("Button empties")]
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;

    [Header("Misc Serialized")]
    [SerializeField] GameObject statText;
    [SerializeField] GameObject player;
    PlayerStats playerStats;

    [Header("Portraits")]
    [SerializeField] GameObject markPortrait;
    [SerializeField] GameObject jackPortrait;
    [SerializeField] GameObject pewdPortrait;
    [Space]
    [SerializeField] Sprite[] markPortraits; //these should each have 5 portraits
    [SerializeField] Sprite[] jackPortraits;
    [SerializeField] Sprite[] pewdPortraits;

    public void MouseOverItem()
    {
        
    }


    public void ReadyShop(IncreaseStatItem[] shopArray)
    {
        button1.GetComponent<OptionButtonScript>().SetAssets(shopArray[0]);
        button2.GetComponent<OptionButtonScript>().SetAssets(shopArray[1]);
        button3.GetComponent<OptionButtonScript>().SetAssets(shopArray[2]);

        statText.GetComponent<TextMeshProUGUI>().text = playerStats.StatStringGen();
    }
}
