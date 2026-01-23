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

    [Header("Button Child Images")]
    [SerializeField] GameObject button1Image;
    [SerializeField] GameObject button2Image;
    [SerializeField] GameObject button3Image;

    [Header("Button Text")]
    [SerializeField] GameObject button1Text;
    [SerializeField] GameObject button2Text;
    [SerializeField] GameObject button3Text;
    TextMeshProUGUI button1TextTMP;
    TextMeshProUGUI button2TextTMP;
    TextMeshProUGUI button3TextTMP;


    [Header("Misc Serialized")]
    [SerializeField] GameObject statText;
    [SerializeField] GameObject player;
    PlayerStats playerStats;

    public void ReadyShop(IncreaseStatItem[] shopArray)
    { //cant use getcomponent on scriptableobj, must access container directly.
        button1Image.GetComponent<Image>().sprite = shopArray[0].itemSprite;
        button2Image.GetComponent<Image>().sprite = shopArray[1].itemSprite;
        button3Image.GetComponent<Image>().sprite = shopArray[2].itemSprite;

        //additionally need to change the button text to the item name.
        button1Text.GetComponent<TextMeshProUGUI>().text = shopArray[0].itemName;
        button2Text.GetComponent<TextMeshProUGUI>().text = shopArray[1].itemName;
        button3Text.GetComponent<TextMeshProUGUI>().text = shopArray[2].itemName;

        statText.GetComponent<TextMeshProUGUI>().text = playerStats.StatStringGen();
    }
}
