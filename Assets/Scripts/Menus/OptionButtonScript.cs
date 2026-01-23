using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class OptionButtonScript : MonoBehaviour
{
    [SerializeField] GameObject buttonText;
    [SerializeField] GameObject buttonImage;

    public IncreaseStatItem containedItem;

    public void SetAssets(IncreaseStatItem incomingItem)
    {
        containedItem = incomingItem;
        buttonImage.GetComponent<Image>().sprite = containedItem.itemSprite;
        buttonText.GetComponent<TextMeshProUGUI>().text = containedItem.itemName;
    }
}
