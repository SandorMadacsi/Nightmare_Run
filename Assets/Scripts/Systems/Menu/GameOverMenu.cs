using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
//Game over menu
{   //Text Object
    public TextMeshProUGUI scoreText;
    public void Stat(int stat)
    {
        // printing energy level to game over scene
        scoreText.text = ("You got :" + stat + " Energy scores");
    }
    public void RestartGame() 
        //Restart game
    {
        SceneManager.LoadScene("Level01");
    }
    public void Exit()
    //Exit game
    {
        SceneManager.LoadScene("StartMenu");
    }
}
