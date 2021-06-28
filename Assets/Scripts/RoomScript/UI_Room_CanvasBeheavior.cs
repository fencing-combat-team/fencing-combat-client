using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 这是房间主要界面的控制类


public class UI_Room_CanvasBeheavior : UI_Room_ViewPanelBehaviour
{
    #region 可设置变量
    public UI_Room_OptionBehavior optionBehavior;
    public UI_Room_WinnerPanel winnerPanel;

    public Text levelname;
    public Text levelmessage;
    public Text setting;
    public Text time;
    public Text ground;

    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;

    public Image image;

    public Button startButton;
    public Button exitButton;
    public Button settingButton;
    #endregion

    #region 单例变量
    //内部变量
    LevelsMessages levelsMessages = LevelsMessages.Instance;
    UI_Room_mes_RoomSetting roomsetting = UI_Room_mes_RoomSetting.Instance;
    UI_Room_mes_PlayerMessageInOneRoom messageInOneRoom = UI_Room_mes_PlayerMessageInOneRoom.Instance;
    LevelMessage temp1;

    bool isPlay = false;

    private float t = 1;
    private float Timeleft = 10;

    //外部会引用到的变量
    public float TimeleftPercent = 1;
    public int Seconds = 10;
    public int Grounds = 3;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        Grounds = roomsetting.roundNums;
    }

    // Update is called once per frame
    void Update()
    {
        //计时以及计算局数部分
        if (isPlay)
        {
            startButton.interactable = false;
            settingButton.interactable = false;
            Timer();
        }
        else
        {
            startButton.interactable = true;
            settingButton.interactable = true;
        }


        //文本同步
        time.text = Seconds.ToString();
        ground.text = Grounds.ToString();
        image.fillAmount = TimeleftPercent;
        score1.text = messageInOneRoom.player1.score.ToString();
        score2.text = messageInOneRoom.player2.score.ToString();
        score3.text = messageInOneRoom.player3.score.ToString();
        score4.text = messageInOneRoom.player4.score.ToString();
    }

    #region 按键点击函数
    public void OnStartButtonClicked()
    {
        isPlay = true;
        newLevelSet();
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

    #region
    void newLevelSet()
    {
        int temp = Random.Range(0, levelsMessages.LevelsList.Count);
        temp1 = levelsMessages.LevelsList[temp];
        levelname.text = temp1.name;
        levelmessage.text = temp1.information;
    }
    void OpenNewLevel()
    {

    }

    void Timer()
    {
        //计数器关卡倒计时
        if (Timeleft >= 0)
        {
            Timeleft -= Time.deltaTime;
            TimeleftPercent = Timeleft / 10f;
        }
        Seconds = (int)Timeleft;

        if (Grounds == 0)
        {
            isPlay = false;
            winnerPanel.Show();
            Reset();
        }


        //关卡判定 每隔一段时间就重新选出一个关卡
        if (Timeleft < 0.1f)
        {
            Timeleft = 10;
            newLevelSet();
            if(Grounds != 0)
            {
                OpenNewLevel();
            }
            Grounds--;
            newLevelSet();
        }

        void Reset()
        {
            Grounds = roomsetting.roundNums;
        }
    }
    #endregion
}

