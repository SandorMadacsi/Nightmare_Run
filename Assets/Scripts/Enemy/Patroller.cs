public class Patroller : Enemy
{
    //Basic patrolling enemy that goes back and forth on the x  axis based on the Enemy script that it inherits from
    protected override void Start()
    {
        //Base Start function 
        base.Start();
        hbar.maxHp(maxHealth);
        //Getting max health value to the health bar
    }
    protected override void Update()
    {
        //Base Update function 
        base.Update();
        //Getting the current hp to the health bar
        hbar.currentHp(health);
    }
}
