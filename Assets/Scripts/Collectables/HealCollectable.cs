using UnityEngine;

public class HealCollectable : MonoBehaviour
{
    //Healing amount
    public int healAmount = 50;
    
    private void OnCollisionEnter2D(Collision2D  obj)
    {
        //On collision with the object player gets healed with the Heal amount and will be added to player's health if it isn't already full otherwise it will only destroy the collectable item.
        PlayerHealth player  = obj.transform.GetComponent<PlayerHealth>();
        if (player.health < player.maxHealth)
        {
            player.health += healAmount;
        }
        Destroy(this.gameObject);
   
    }
}

