using System;
using Core;
using UI.Data;
using UnityEngine.UI;
using Utils;

//这是关卡设置界面的控制类

namespace UI.Room
{
    public class RoomOptionBehavior : ViewPanelBehaviourBase
    {
        public RoomSetting roomSetting;
    
    
    
        [Autowired(GameObject = "OptionPanel/SliderRoundNum")]
        private Slider sliderRoundNum;
        [Autowired(GameObject = "OptionPanel/SliderPlayerNum")]
        private Slider sliderPlayerNum;
        [Autowired(GameObject = "OptionPanel/SliderLivesNum")]
        private Slider sliderLivesNum;
        [Autowired(GameObject = "OptionPanel/SliderRecoverTime")]
        private Slider sliderRecoverTime;


        public void Awake()
        {
            this.InitComponents();
        }

        protected override void OnShow()
        {
            sliderPlayerNum.value = roomSetting.playerNumbers;
            sliderLivesNum.value = roomSetting.lives;
            sliderRoundNum.value = roomSetting.round;
            sliderRecoverTime.value = roomSetting.recoveryTime;
        }

        public void OnExitClick()
        {
        
            roomSetting.playerNumbers = Convert.ToInt32(sliderPlayerNum.value);
            roomSetting.lives = Convert.ToInt32(sliderLivesNum.value);
            roomSetting.round = Convert.ToInt32(sliderRoundNum.value);
            roomSetting.recoveryTime = sliderRecoverTime.value;
        
            roomSetting.OnSettingChange();

            this.Hide();
        }
    }
}
