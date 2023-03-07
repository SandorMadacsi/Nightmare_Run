using UnityEngine;

public class EnemyAmmo : Ammo
{
    //Ammo that the Gunner enemy uses
    //Body of bullet
    public Rigidbody2D enemy;

    void Start()
    {
        //Body of Gunner enemy
        enemy = GameObject.Find("Gunner").GetComponent<Rigidbody2D>();
    }
    protected override void Update()
    {
        base.Update();
        //Bullet is moving with the enemy
        bullet.velocity = transform.right * speed;
        bullet.velocity += enemy.velocity;
    }
}
