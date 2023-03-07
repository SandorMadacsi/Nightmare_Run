using UnityEngine;

public class Parallax : MonoBehaviour
{
    //Based on[14]AdamCYounis (2021). 
    //camera and player objects
    public Camera cam;
    public Transform player;
    
    //Storing the value of x and y
    private Vector2 _startPos;
    //z is stored separately as we dont move on the z axis
    private float _startZ;
    //Calculating the distance of the camera position from the starting position
    private Vector2 DistanceFromStart => (Vector2)cam.transform.position - _startPos;
    //Storing the distance between the background object and player
    private float DistFromSubject => transform.position.z - player.position.z;

    //Deciding whether to use the far or near clipping Plane based on the z position of the actual object from the camera
    private float CPlane =>
        (cam.transform.position.z + (DistFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
    //Parallax factor is bigger if the subject is further from the player therefore it will move slower. Objects that are near to the player will move much faster.
    private float ParallaxFactor => Mathf.Abs(DistFromSubject / CPlane);
    
   public void Start()
    {
        //Starting position x and y
        _startPos = transform.position;
        //Starting position z
        _startZ = transform.position.z;
    }
   void Update()
    { 
        //Moving the background objects based on the parallax Factor
     var newPos = _startPos + DistanceFromStart * ParallaxFactor;
     transform.position = new Vector3(newPos.x, newPos.y, _startZ);

    }
}
