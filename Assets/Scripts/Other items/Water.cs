using UnityEngine;

public class Water : MonoBehaviour
{
    //Water damage
    [SerializeField] protected int damage;

    private void OnTriggerStay2D(Collider2D other)
    {
        //dealing damage to player on Collision
        if (other.gameObject.CompareTag("Player"))
        {//Accessing the playerJump and playerHealth scirpts
            other.gameObject.GetComponent<PlayerJump>().Jump();
            PlayerHealth player = other.transform.gameObject.GetComponent<PlayerHealth>();
            player.health -= damage;
        }
    }
}

