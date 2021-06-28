using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Core;
using UI.Room;
using Utils;

//这是关卡设置界面的控制类

public class UI_Room_OptionBehavior : UI_Room_ViewPanelBehaviour
{
    public RoomSetting roomSetting;
    
    
    
    [Autowired(GameObject = "OptionPanel/SliderRoundNum")]
    private Slider sliderroundnum;
    [Autowired(GameObject = "OptionPanel/SliderPlayerNum")]
    private Slider sliderplayerNum;
    [Autowired(GameObject = "OptionPanel/SliderLivesNum")]
    private Slider sliderlivesNum;
    [Autowired(GameObject = "OptionPanel/SliderRecoverTime")]
    private Slider sliderRecoverTime;


    public void Start()
    {
        this.InitComponents();
    }

    public void OnExitClick()
    {
        
        roomSetting.playerNumbers = Convert.ToInt32(sliderplayerNum.value);
        roomSetting.lives = Convert.ToInt32(sliderlivesNum.value);
        roomSetting.round = Convert.ToInt32(sliderroundnum.value);
        roomSetting.recoveryTime = sliderRecoverTime.value;
        
        roomSetting.OnSettingChange();

        this.Hide();
    }
}
