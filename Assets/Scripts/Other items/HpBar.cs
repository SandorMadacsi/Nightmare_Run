using UnityEngine;

using UnityEngine.UI;
public class HpBar : MonoBehaviour
//Infuenced by [6]Brackeys (2017). 
{
    //Slider object
    public Slider s;

    public void currentHp(int h)
    //Updating the slider with current value
    {
        s.value = h;
    }

    public void maxHp(int h)
    //Setting the max value of the slider to the health of the player and also fills up the slider to max value to fill the bar
    {
        s.maxValue = h;
        s.value = h;
    }

}
