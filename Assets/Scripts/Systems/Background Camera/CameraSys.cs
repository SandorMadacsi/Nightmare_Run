using UnityEngine;

public class CameraSys : MonoBehaviour
{
    public Transform player;
    //Influenced by [2] Lets Make A Game Together. (2017). 
    // minimum and maximum values(both in x and y axis) that is included in the camera frame
    public float xMin, xMax, yMin, yMax;
    
   void FixedUpdate()
    {
        //The camera can move on a path between the minimum and maximum values on the x and y axis
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
