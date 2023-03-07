using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D body;
    //[SerializeField] protected Animator cAnimation;
    //jumping force that works against gravity
    public int pJumpForce;
    
    // the ratio of how fast the player should fall from jumping
    public float fRatio;
    
    //the ratio of how fast the player should jump if the button is only pressed 
    public float lJumpRatio ;
    public int numOfJumps ;
    
    
    // advanced jump
    //threshold for jumping after collision ended
    public float elapsedGrounded;
    
    //last time the player collided with ground object
    [SerializeField] protected float lastGrounded;
    
    //initialization for ground
    public LayerMask gLayer;
    public LayerMask oLayer;
    public bool isOnGround = false;
    // Object that checks if the character is on the ground
    public float gRadius;
    public Transform gCheck;
    // Start is called before the first frame update
    void Start()
    {
        //initializing
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calling all functions
        Jump();
        PolishedJump();
        GroundChecker();
        SpikePit();
    }
    
    public void Jump()
    {
        //jumping if jump button pressed and (player is on ground or its at the edge or it has jump available)
        // By checking if the value between the current time and the last time the player touched the ground is less than or equal to the treshhold value , the player is able to jump right at the edge of a platform to make the jump smoother
        if (Input.GetButtonDown("Jump") && (isOnGround == true || Time.time - lastGrounded <= elapsedGrounded ))
        {
            //numOfJumps --;
            //Jumping  by multiplying the up vector with jumpforce variable
            body.velocity = Vector2.up * pJumpForce;
        }
    }

    private void PolishedJump()
        //Script was influenced by source [19]Craft Games(2019). The source had a very clear Idea of making the player able to jump even at the edge of the platform.
    {   //if the player is falling the gravity is manipulated to make the player move quicker
        if (body.velocity.y < 0)
        {
            body.velocity += Vector2.up * (Physics2D.gravity * ((fRatio - 1) * Time.deltaTime));
        }
        //if the jump button is  briefly pressed for jumping the jump curve will be less steep and more even by manipulating the gravity with a smaller value.
        else if (body.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            body.velocity += Vector2.up * (Physics2D.gravity * ((lJumpRatio - 1) * Time.deltaTime));
        }
    }
    
    void GroundChecker()
    {
        //collision detection if the ground checker object on the player touches the ground object(in the   ground layer) based on the ground radius value then the player is on the ground otherwise not
        Collider2D col = Physics2D.OverlapCircle(gCheck.position, gRadius, gLayer);
        if (col != null)
        {
            isOnGround = true;
        }
        else
        {
            if (isOnGround)
            {
                lastGrounded = Time.time;
            }
            isOnGround = false;
        }
    }

    void SpikePit()
    {
        //Player collides with spike pit (on the obstacle layer)
        Collider2D col = Physics2D.OverlapCircle(gCheck.position, gRadius, oLayer);
        //if the ground checker on the player is colliding with the pit
        if (col != null)
        {
            //player will go up and right a bit to indicate visually that the spike pit hurts the player
            body.AddForce(Vector2.up*300);
            body.AddForce(Vector2.right *200);
        }
    }
}
