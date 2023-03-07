using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Body of player
    public Rigidbody2D body;
    //Animator
    [SerializeField] protected Animator cAnimation;
    //Character x position
    [SerializeField] protected float characterX;
    //Facing right state
    public bool faceRight;
    //Movement speed
    public int pSpeed;

   private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cAnimation = GetComponent<Animator>();
        faceRight =true;
    }

    // Update is called once per frame
    private void Update()
    {
        //Moving the player function
        Move();
    }

    private void Move()
    {
        //Controlling character on the x axis with right and left arrows
        characterX = Input.GetAxis("Horizontal") * pSpeed;
        

        //flipping sprite to left if going on x axis in negative direction
        if (characterX < 0.0f)
        {
            transform.localScale = (new Vector3(-8f, 8f, 1f));
            faceRight = false;
        }
        //flipping sprite to right if going on x axis in positive direction
        else if (characterX > 0.0f)
        {
            transform.localScale = (new Vector3(8f, 8f, 1f));
            faceRight = true;
        }
        
        //character animation
        //run animation if not moving
        if(characterX != 0)
        {
            cAnimation.SetBool("isRun",true);
        }
        else
        //idle animation otherwise
        {
            cAnimation.SetBool("isRun",false);
        }

        // moving the body of character with the player speed on the x axis
        body.velocity = 
            new Vector2(characterX , body.velocity.y);
    }
    
}


