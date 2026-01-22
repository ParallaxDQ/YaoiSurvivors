using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ContinueGame()
        {
            //use to unpause the game
        }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}

