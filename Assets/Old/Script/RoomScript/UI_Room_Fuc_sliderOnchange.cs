using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Room_Fuc_sliderOnchange : MonoBehaviour
{
    public Slider slider;
    public Text text;

    public void Onchange()
    {
        text.text = slider.value.ToString();
    }

}
