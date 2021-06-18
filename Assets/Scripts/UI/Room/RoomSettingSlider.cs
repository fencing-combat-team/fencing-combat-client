using System;
using Core;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Room
{
    public class RoomSettingSlider: MonoBehaviour
    {
        [Autowired]
        private Slider _slider;
        [SerializeField]
        [Tooltip("Slider显示值的位置")]
        private Text _text;

        private void Start()
        {
            this.InitComponents();
            _slider.onValueChanged.AddListener(val =>
            {
                _text.text = val.ToString();
            });
        }
        
        
    }
}