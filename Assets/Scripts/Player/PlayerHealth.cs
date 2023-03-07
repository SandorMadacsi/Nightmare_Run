using UnityEngine;
using  UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

   [SerializeField] protected Rigidbody2D body;
   public  int health;
   public int maxHealth;
  // public GameObject healthUI;
   public HpBar hbar;
   private void Awake()
   {
       body = GetComponent<Rigidbody2D>();
       maxHealth = 200;
       health = maxHealth;
   }

   // Update is called once per frame
   private void Update()
    {
        hbar.currentHp(health);
        //if the player falls bellow the surface or it's health goes bellow 0 then player dies
        if (body.transform.position.y <= -70 || health <= 0
        )
        {
            //Triggers the level scene to start agin
            Die();
        }
    }

    private void Die()
    {
        //Loads the beginning of the level
        SceneManager.LoadScene("GameOver");
        
       
    }
}
