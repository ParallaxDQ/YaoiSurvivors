using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{ 
    //to be used for the OnPress event on menu buttons
    public void PlayGame()
    {
        SceneManager.LoadScene("GameWorld");
    }

    public void QuitGame()
    {
        Debug.Log("Hurray, you quit!");
        Application.Quit(); //will only quit in the build.
    }

}
