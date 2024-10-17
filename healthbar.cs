using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{


    public Slider healthslider;
    // Start is called before the first frame update
    public void SetSlider (float amount){

        healthslider.value=amount;
    }


public void SetSliderMax(float amount){

    healthslider.maxValue=amount;
    SetSlider(amount);
}

}
