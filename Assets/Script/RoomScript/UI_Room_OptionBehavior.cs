using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//这是关卡设置界面的控制类

public class UI_Room_OptionBehavior : UI_Room_ViewPanelBehaviour
{
    public UI_Room_mes_RoomSetting roomSetting;

    public Slider sliderroundnum;
    public Slider sliderplayerNum;
    public Slider sliderlivesNum;
    public Slider sliderRecoverTime;

    public Image player1;
    public Image player2;
    public Image player3;
    public Image player4;




    public void OnExitClick()
    {
        /*
        roomSetting.GetInstance().PlayerNum = Convert.ToInt32(sliderplayerNum.value);
        roomSetting.GetInstance().LivesNum = Convert.ToInt32(sliderlivesNum.value);
        roomSetting.GetInstance().roundNums = Convert.ToInt32(sliderroundnum.value);
        roomSetting.GetInstance().recovertime = sliderRecoverTime.value;
        */
            
        switch (Convert.ToInt32(sliderplayerNum.value))
        {
            case 2:
                player1.transform.gameObject.SetActive(true);
                player2.transform.gameObject.SetActive(true);
                player3.transform.gameObject.SetActive(false);
                player4.transform.gameObject.SetActive(false);
                break;

            case 3:
                player1.transform.gameObject.SetActive(true);
                player2.transform.gameObject.SetActive(true);
                player3.transform.gameObject.SetActive(true);
                player4.transform.gameObject.SetActive(false);
                break;

            case 4:
                player1.transform.gameObject.SetActive(true);
                player2.transform.gameObject.SetActive(true);
                player3.transform.gameObject.SetActive(true);
                player4.transform.gameObject.SetActive(true);
                break;

            default:
                break;

        }
           

        this.Hide();
    }
}
