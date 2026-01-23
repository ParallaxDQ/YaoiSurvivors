using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    [TextArea(3, 5)]
    public string dialogueText;
    public Sprite characterSprite;
}

[System.Serializable]
public class VisualNovelSequence
{
    public string characterTrigger;
    public DialogueLine[] dialogueLines;
}

public class VisualNovelManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private Image characterImage;
    [SerializeField] private GameObject continueIndicator;
    
    [Header("Sequences")]
    [SerializeField] private VisualNovelSequence[] sequences;
    
    private DialogueLine[] currentSequence;
    private int currentLineIndex = 0;
    private string returnScene;
    
    void Start()
    {
        // Validate references
        if (dialogueText == null) Debug.LogError("Dialogue Text not assigned!");
        if (characterNameText == null) Debug.LogError("Character Name Text not assigned!");
        
        string triggeredCharacter = PlayerPrefs.GetString("VN_Character", "Mark");
        returnScene = PlayerPrefs.GetString("VN_ReturnScene", "GameScene");
        
        foreach (var sequence in sequences)
        {
            if (sequence.characterTrigger == triggeredCharacter)
            {
                currentSequence = sequence.dialogueLines;
                break;
            }
        }
        
        if (currentSequence != null && currentSequence.Length > 0)
        {
            DisplayLine(0);
        }
        else
        {
            Debug.LogError("No dialogue sequence found for " + triggeredCharacter);
            ReturnToGame();
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            AdvanceDialogue();
        }
    }
    
    void DisplayLine(int index)
    {
        if (index >= currentSequence.Length)
        {
            EndVisualNovel();
            return;
        }
        
        DialogueLine line = currentSequence[index];
        
        if (characterNameText != null)
            characterNameText.text = line.characterName;
            
        if (dialogueText != null)
            dialogueText.text = line.dialogueText;
        
        if (characterImage != null && line.characterSprite != null)
        {
            characterImage.sprite = line.characterSprite;
        }
        
        currentLineIndex = index;
    }
    
    void AdvanceDialogue()
    {
        DisplayLine(currentLineIndex + 1);
    }
    
    void EndVisualNovel()
    {
        string character = PlayerPrefs.GetString("VN_Character", "Mark");
        PlayerPrefs.SetInt($"VN_Completed_{character}", 1);
        
        ReturnToGame();
    }
    
    void ReturnToGame()
    {
        SceneManager.LoadScene(returnScene);
    }
}