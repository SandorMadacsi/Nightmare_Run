using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public GameObject scoreUI;
    public GameOverMenu stats;
    
    // Update is called once per frame
    void Update()
    {
        //Storing the score (energy) on the UI in form of text
        scoreUI.gameObject.GetComponent<TextMeshProUGUI>().text = ("" + score);
        //Calling the gameOverMenu script for displaying the achieved score when player dies.
        stats.Stat(score);
    }
}
