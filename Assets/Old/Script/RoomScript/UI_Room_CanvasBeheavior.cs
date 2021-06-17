using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ���Ƿ�����Ҫ����Ŀ�����


public class UI_Room_CanvasBeheavior : UI_Room_ViewPanelBehaviour
{
    #region �����ñ���
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

    #region ��������
    //�ڲ�����
    LevelsMessages levelsMessages;
    LevelMessage temp1;

    bool isPlay = false;

    private float t = 1;
    private float Timeleft = 10;

    //�ⲿ�����õ��ı���
    public float TimeleftPercent = 1;
    public int Seconds = 10;
    public int Grounds = 3;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            startButton.interactable = !isPlay;
            settingButton.interactable = !isPlay;
            Timer();
        }


        //
        time.text = Seconds.ToString();
        ground.text = Grounds.ToString();
        image.fillAmount = TimeleftPercent;

    }

    #region �����������
    public void OnStartButtonClicked()
    {
        isPlay = true;
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
        if (Timeleft >= 0)
        {
            Timeleft -= Time.deltaTime;
            TimeleftPercent = Timeleft / 10;
        }
        else { Timeleft = 10; }

        t += Time.deltaTime;
        if (t >= 1)
        {
            Seconds--;
            t = 0;
        }
        if (Seconds < 0)
        {
            Seconds = 10;
            newLevelSet();
            OpenNewLevel();
            if(Grounds != 0) { Grounds--; }
        }
        if (Grounds == 0)
        {
            isPlay = false;
        }
    }
    #endregion
}

