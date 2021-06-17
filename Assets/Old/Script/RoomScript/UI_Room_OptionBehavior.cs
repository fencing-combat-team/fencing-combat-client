using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//���ǹؿ����ý���Ŀ�����

public class UI_Room_OptionBehavior : UI_Room_ViewPanelBehaviour
{
    UI_Room_mes_RoomSetting roomSetting;

    public Slider sliderroundnum;
    public Slider sliderplayerNum;
    public Slider sliderlivesNum;
    public Slider sliderRecoverTime;

    public Image player1;
    public Image player2;
    public Image player3;
    public Image player4;

    public Text text;


    public void OnExitClick()
    {
        /*
        roomSetting.PlayerNum = Convert.ToInt32(sliderplayerNum.value);
        roomSetting.LivesNum = Convert.ToInt32(sliderlivesNum.value);
        roomSetting.roundNums = Convert.ToInt32(sliderroundnum.value);
        roomSetting.recovertime = sliderRecoverTime.value;
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

        text.text = "��Ҫ���еĹؿ�����"+sliderroundnum.value.ToString()+"\nÿ����Ϸ��ҵ���������"+sliderlivesNum.value.ToString()+"\n��Ҹ���ʱ�䣺"+sliderRecoverTime.value.ToString()+"\n�Ƿ������ߣ�" ;

        this.Hide();
    }
}
