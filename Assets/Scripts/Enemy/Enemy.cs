using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    //Base stats that all enemies have
    //The some of the script mechanics was influenced by [3] and [7] source such as the patrolling logic and the two body colliders method in order to detect walls front of the enemy
    //Health and damage
    public int health;
    public  int damage;
    
    //Movement speed
    [SerializeField] protected int mSpeed;
    
    [SerializeField] protected int maxHealth;
    
    //Bool for when the enemy should patrol back and forth(move)
    [SerializeField] protected bool isPatrolling;
    //Bool for enemy to turn around 
    [SerializeField] protected bool isFlip;
    
    //Attack distance if player gets near
    [SerializeField] protected int aDistance; 
    //Body of enemy
    public Rigidbody2D enemy;
    //Position of player
    public Transform player;
    //Position of ground checker object
    public Transform gCheckPos;
    //Ground layer mask
    public LayerMask gLayer;
    //One of the colliders (upper body) on enemy that checks walls
    public Collider2D bodyCol;
    //health bar object
    public HpBar hbar;
    
    protected  virtual void Start()
    {
        
        health = maxHealth;
        //Starts up patrolling back and forth
        isPatrolling = true;
        //Assigning body to enemy
        enemy = GetComponent<Rigidbody2D>();
        //Assigning the position of the Player object
        player = GameObject.Find("Player").transform;
    }

    protected virtual void Update()
    {
        //if enemy needs to patrol then call the move function
        if (isPatrolling)
        {
            Move();
        }
    }

    protected virtual void FixedUpdate()
    {
        //If enemy needs to patrol it should check the ground based on the checker object position while moving
        if (isPatrolling)
        {
            GroundCheck();
        }
    }

    protected virtual void Move()
    {
        //If the enemy upper body colider bumps into a wall that is on the ground layer or the ground checker tells the enemy to flip then it should call the flip function
        if ( isFlip || bodyCol.IsTouchingLayers(gLayer))
        {
            Flip();
        }
        //Move the enemy on the x axes based on the movement speed
        enemy.velocity =  new Vector2(1, 0) * mSpeed;
    }
    
    protected virtual void Flip()
    {
        //Stops the patrolling
        isPatrolling = false;
        //Flips the enemy localscale on the x axis by multiplying it by negative one
        transform.localScale = (new Vector2(transform.localScale.x * -1, transform.localScale.y));
        //Changes the movement direction by manipulating the movement speed by negative one
        mSpeed *= -1;
        //Turns the patrolling back on
        isPatrolling = true;
    }
    protected virtual void GroundCheck()
    {
        //Boolean that tels the enemy if the ground checker circle object is not colliding with the ground (object on ground layer) within the checker object radius
        //If it is true it tells the enemy to flip ( change direction
         isFlip = !Physics2D.OverlapCircle(gCheckPos.position, 0.1f, gLayer);
    }
    
    protected void  OnCollisionEnter2D(Collision2D  obj)
    {
        //IF enemy hits Player or vice versa then Player takes damage each time they collide
        if (obj.gameObject.tag.Equals("Player"))
        {
            PlayerHealth player = obj.transform.gameObject.GetComponent<PlayerHealth>();
            player.health -= damage;
        }

    }

 }
