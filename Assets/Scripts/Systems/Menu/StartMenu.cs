using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    //Influenced by [5]Brackeys (2017). 

    public void StartGame()
    {
        //By starting the game loads the upcoming scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Quit game
        Application.Quit();
    }
}
