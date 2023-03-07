using UnityEngine;
using UnityEngine.SceneManagement;


public class Diary : MonoBehaviour
{
    //Diary objects leads to end scene on collision
    public Rigidbody2D diary;
    
    void OnCollisionEnter2D(Collision2D trig)
        {
            //If the end of level object is reached it brings back the start of the scene
            SceneManager.LoadScene("EndScene");
        }
}
