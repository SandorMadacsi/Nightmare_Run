using UnityEngine;
using UnityEngine.SceneManagement;

public  class PauseMenu : MonoBehaviour
{
    //Influenced by [20]Brackeys (2017). 

    public static bool isPaused = false;

    public GameObject pauseUI;
    // Update is called once per frame
    void Update()
    {
        
        //By pressing escape key user can switch between pausing and resuming game by switching the state of isPaused boolean
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //Resume function
                ResumeGame();
            }
            else
            {
                //Pause function
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        //Activate pause ui, and freeze game time
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

   public void ResumeGame()
    {
        //Deactivate pause ui, and unfreeze game time
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

   public void RestartGame()
   {
       //Calling resume function when player restarts the game and loads level
       ResumeGame();
       SceneManager.LoadScene("Level01");
       
   }

   public void ExitGame()
   {
       //Exit game
       Application.Quit();
   }
}
