using System.Collections;
using System.Collections.Generic;
using UI.Room;
using UnityEngine;
using UnityEngine.UI;


// 这是房间主要界面的控制类


public class UI_Room_CanvasBeheavior : UI_Room_ViewPanelBehaviour
{
    #region 可设置变量
    public UI_Room_OptionBehavior optionBehavior;

    public Text levelname;
    public Text levelmessage;
    public Text setting;
    public Text time;
    public Text ground;

    public Image image;

    public Button startButton;
    public Button exitButton;
    public Button settingButton;
    #endregion


    [SerializeField]
    [Tooltip("房间设置")]
    private RoomSetting roomSetting;
    #region 单例变量
    //内部变量
    LevelsMessages levelsMessages = LevelsMessages.Instance;
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
        Grounds = roomSetting.round;
    }

    // Update is called once per frame
    void Update()
    {
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


        //
        time.text = Seconds.ToString();
        ground.text = Grounds.ToString();
        image.fillAmount = TimeleftPercent;

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
    }
    #endregion
}

