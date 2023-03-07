using UnityEngine;

public class Spike : MonoBehaviour
{
    //Spike pit object that damages player
    //Damage that the player will take
    //Script was influenced by [4]GucioDevs (2015). 
    [SerializeField] protected int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        //dealing damage to player on Collision
        if (other.collider.CompareTag("Player"))
        {
             other.gameObject.GetComponent<PlayerJump>().Jump();
            PlayerHealth player = other.transform.gameObject.GetComponent<PlayerHealth>();
            player.health -= damage;
        }
    }
}