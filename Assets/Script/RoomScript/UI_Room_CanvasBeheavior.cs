using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ���Ƿ�����Ҫ����Ŀ�����


public class UI_Room_CanvasBeheavior : UI_Room_ViewPanelBehaviour
{
    #region �����ñ���
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

    #region �����������
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

