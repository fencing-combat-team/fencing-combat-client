using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 这是房间主要界面的控制类


public class UI_Room_CanvasBeheavior : UI_Room_ViewPanelBehaviour
{
    #region 可设置变量
    public UI_Room_OptionBehavior optionBehavior;

    public Button startButton;
    public Button exitButton;
    public Button settingButton;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region 按键点击函数
    public void OnStartButtonClicked()
    {
        startButton.interactable = false;
        settingButton.interactable = false;
    }

    public void OnSettingButtonClicked()
    {
        optionBehavior.Show();
    }
    public void OnExitButtonClicked()
    {
        startButton.interactable = true;
        settingButton.interactable = true;
    }
    #endregion
}

