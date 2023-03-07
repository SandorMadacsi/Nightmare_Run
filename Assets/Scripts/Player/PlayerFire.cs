using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // attack speed
    public float rate = 0.1f;
    // firing point position
    public Transform firePos;
    //bullet object
    public GameObject ammo;
    // time to fire based on the fire rate and time
    private float untilFire;
    private PlayerMove move;

    private void Start()
    {
        //Player_Move script object
        move = gameObject.GetComponent<PlayerMove>();
    }

    private void Update()
    {
        //if left mouse button pressed and able to shoot based on the untilFire variable then shoot
        if (Input.GetMouseButtonDown(0) && untilFire < Time.time)
        {
            Fire();
            //constantly change the untilFire value to reset after shooting
            untilFire = Time.time + rate;
        }
    }

    // Firing the bullet in the appropriate direction
    // If  the enemy is not facing right then rotate direction to opposite side
    private void Fire()
    {
        float direction = !move.faceRight ? 180f : 0f;
        Instantiate(ammo, firePos.position, Quaternion.Euler(new Vector3(0f, 0f, direction)));
    }
}
