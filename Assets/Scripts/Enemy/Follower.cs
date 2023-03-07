using UnityEngine;

public class Follower : Enemy
// Follower enemy that goes towards the player if the player is within the attack distance radius
{
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

        //Checking if player is in the attack distance radius
        if (Vector2.Distance(enemy.position, player.position) < aDistance)
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
                //Flipping the enemy
                Flip();
             
            }
            //Stop patrolling if player is in range of attack
            isPatrolling = false;
            //Attack the player
            Attack();
        }
        
        //Otherwise if player not in attack range then go back to patrolling
        else
        {
            isPatrolling = true;
        }
    }

    private void Attack()
     {
         //Getting the x axis of player position  and the y axis of the enemy into a new vector
         Vector3 newTarget = new Vector2(player.position.x, transform.position.y);
         //Going towards the player based on the new target. This way the player has the same y axis as the enemy so the enemy will only follow the player on the x axis.
         transform.position = Vector2.MoveTowards(transform.position, newTarget, 0.02f);
     }
}
