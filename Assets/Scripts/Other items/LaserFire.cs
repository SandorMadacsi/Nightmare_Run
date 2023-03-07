using UnityEngine;

public class LaserFire : MonoBehaviour
{
    //Ammo for a tower object that constantly fires
    
    //Firing rate
    public float rate = 1f;
    //Firing point position
    public Transform firePos;
    //Bullet object
    public GameObject ammo;
    //Time to wait until fire
    [SerializeField]protected float untilFire;

    private void Update()
    {
        //If it is time to fire then the tower fires
        if ( untilFire < Time.time)
        {
            Fire();
            //Constantly change the untilFire value to reset after shooting
            untilFire = Time.time + rate;
        }
    }
    private void Fire()
    {
        //Spawning ammo object then rotate it on Z axis to fly towards left direction
        Instantiate(ammo, firePos.position, Quaternion.Euler(new Vector3(0f, 0f, 180f)));
    }

}



