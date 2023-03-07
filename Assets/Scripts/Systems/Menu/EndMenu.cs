using UnityEngine;
using UnityEngine.SceneManagement;
public class EndMenu : MonoBehaviour
{
    public void Exit()
        //Exit game
    {
        SceneManager.LoadScene("StartMenu");
    }
}
