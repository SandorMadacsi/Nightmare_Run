using UnityEngine;

public class Gunner : Enemy
{
    public float rate = 0.8f;
    // firing point position
    public Transform firePos;
    //  //bullet object
    public GameObject ammo;
    // time until enemy is able to fire again
    [SerializeField]protected float untilFire;
    
    protected override void Start()
    {
        //Getting the max health of enemy to the hp bar 
        base.Start();
        hbar.maxHp(maxHealth);
    }

protected override void Update()
    
{
    //Getting the current health into the hp bar (It updates the health bar if enemy takes damage)
    hbar.currentHp(health);

    //Patrolling
     if (isPatrolling)
     {
         //Move the enemy
         Move();
     }

     if (Vector2.Distance(enemy.position, player.position) < aDistance && untilFire < Time.time)
     {
         // Initially my sprites are facing left as the player is coming from that side so the left  is referred to as positive direction
         //Flipping the enemy if :
         //- Player is behind the enemy and facing into the positive direction (left)
         //Or
         //- Player is front of the enemy and facing the negative direction (right)
         //the algorithm was influenced by source [7]The Game Dev_(2020)
         if (player.position.x > transform.position.x && transform.localScale.x > 0 ||
             player.position.x < transform.position.x && transform.localScale.x < 0)
         {
             Flip();
         }

         //Stop patrolling if player is in range of attack
         isPatrolling = false;
         //Attack the player
         Attack();
         //Based on the firing rate we save the time we fired
         untilFire = Time.time + rate;
     }
     
     //Otherwise if player not in attack range then go back to patrolling
     else
     {
         isPatrolling = true;
     }
}

private void Attack()
    {
        //If the player is front of the enemy the bullet  on the z axis will rotate 180 degrees to Left direction(as the bullet goes right initially)
        //Otherwise the bullet will go right direction (it will not rotate on the z axis)
        float direction = player.position.x < transform.position.x ? 180f : 0f;
        //Spawning a new bullet object from the firing object position  and rotate it according to where the player stands
        Instantiate(ammo, firePos.position, Quaternion.Euler(new Vector3(0f, 0f, direction)));
    }

}