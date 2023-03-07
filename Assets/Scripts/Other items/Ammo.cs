using UnityEngine;

public class Ammo : MonoBehaviour
{
    //speed that the bulled will move at
    public float speed = 10f;
    //damage dealt to the object that the bullet hits
    public int damage = 20;
    
   // public Rigidbody2D play;
   //Body of bullet
    public Rigidbody2D bullet;
   // private PlayerMove move;
   //Body of player
    private Rigidbody2D player;
    public GameObject diary;
    
     void Start()
    {

        //Getting the body of player object
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
     protected virtual void Update()
    {
        //Bullet initially goes from left to right based on the speed
        bullet.velocity = transform.right * speed;

    }
    void OnEnable() {
        GameObject[] collectables = GameObject.FindGameObjectsWithTag("Collectable");

        foreach (GameObject obj in collectables) {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //dealing damage to enemy when bullet hits
        if (other.collider.CompareTag("Enemy"))
            
        {
            Enemy enemy = other.transform.gameObject.GetComponent<Enemy>();
            enemy.health -= damage;
            Debug.Log(enemy.health); 
            //If the enemy is at 0 health or bellow when the bullet hits it will kill the enemy object
            if (enemy.health <= 0)
            {
                Vector3 pos = enemy.transform.position;
                if (enemy.gameObject.name == "Gunner")
                {
                    Instantiate(diary,pos, Quaternion.Euler(new Vector3(0,0,0))); 
                    Destroy(other.gameObject);
                }
                Destroy(other.gameObject);
            }
            
        }
        //Dealing damage to player when bullet hits
        if (other.collider.CompareTag("Player"))
        {
            PlayerHealth player = other.transform.gameObject.GetComponent<PlayerHealth>();
            player.health -= damage;
            Debug.Log(player. health);
        }
        //Destroying bullet object after collision
        Destroy(gameObject);
    }
}
