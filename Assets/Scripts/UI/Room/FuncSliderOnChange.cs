using UnityEngine;
using UnityEngine.UI;

namespace UI.Room
{
    public class FuncSliderOnChange : MonoBehaviour
    {
        public Slider slider;
        public Text text;

        public void Onchange()
        {
            text.text = slider.value.ToString();
        }

    }
}
