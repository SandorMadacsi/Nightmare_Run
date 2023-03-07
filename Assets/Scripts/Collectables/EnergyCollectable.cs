using UnityEngine;

public class EnergyCollectable : MonoBehaviour
{
    //Energy is a collectable that is essentially is score
    // energy amount
    public int energyAmount = 10;
    private void OnCollisionEnter2D(Collision2D  obj)
    {
        //On collision with the object player gets charged  with the Energy amount and will be added to the overall score
        PlayerScore player  = obj.transform.GetComponent<PlayerScore>();
      player.score += energyAmount;
      //After collision, object gets destroyed
      Destroy(this.gameObject);
    }
}

