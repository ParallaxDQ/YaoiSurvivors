using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenuScript : MonoBehaviour
{
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    [SerializeField] GameObject statText;
    [SerializeField] GameObject player;
    PlayerStats playerStats;

    public void ReadyShop(ScriptableObject[] shopArray)
    { //cant use getcomponent on scriptableobj, must access container directly.
        button1.GetComponentInChildren<Image>().sprite = shopArray[0].GetComponent<Image>().sprite;
        button2.GetComponentInChildren<Image>().sprite = shopArray[1].GetComponent<Image>().sprite;
        button3.GetComponentInChildren<Image>().sprite = shopArray[2].GetComponent<Image>().sprite;

        //additionally need to change the button text to the item name.

        statText.GetComponent<TextMeshProUGUI>().text = playerStats.StatStringGen();
    }
}
