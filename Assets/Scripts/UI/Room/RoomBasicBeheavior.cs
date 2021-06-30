using System.Linq;
using GamePlay.Data;
using Managers;
using UI.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


// 这是房间主要界面的控制类


namespace UI.Room
{
    public class RoomBasicBeheavior : ViewPanelBehaviourBase
    {
        #region 可设置变量

        public RoomOptionBehavior optionBehavior;
        public WinnerPanel winnerPanel;

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


        [Tooltip("房间设置")]
        public RoomSetting roomSetting;

        public PlayerRoomData roomData;
        [FormerlySerializedAs("roomStatu")]
        public RoomStatus roomStatus;


        #region 单例变量

        bool isPlay = false;

        private float t = 1;
        private float Timeleft = 10;

        //外部会引用到的变量
        public float TimeleftPercent = 1;
        public int Seconds = 10;
        public int Grounds = 3;

        //暂停判断器
        private bool PAUSE = false;

        #endregion

        private PlayerDataShower[] players;


        // Start is called before the first frame update
        void Start()
        {
            if (roomStatus.isGaming)
            {
                isPlay = true;
                Grounds = roomStatus.GroundsRemained;
                roomData.GetById(1).score += roomStatus.score1;
                roomData.GetById(2).score += roomStatus.score2;
                roomData.GetById(3).score += roomStatus.score3;
                roomData.GetById(4).score += roomStatus.score4;
            }
            else
            {
                Grounds = roomSetting.round;
            }

            //初始化颜色选择器
            foreach (var colorSelector in GameObject.Find("PlayerPanel").GetComponentsInChildren<PlayerColorSelector>())
            {
                colorSelector.PlayerData = roomData.GetById(colorSelector.playerId);
            }

            players = GameObject.Find("PlayerPanel").GetComponentsInChildren<PlayerDataShower>();
            foreach (var dataShower in  players)
            {
                dataShower.playerData = roomData.GetById(dataShower.playerId);
            }
        }


        // Update is called once per frame
        void Update()
        {
            if (!PAUSE)
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
            }


            //文本同步
            time.text = Seconds.ToString();
            ground.text = Grounds.ToString();
            image.fillAmount = TimeleftPercent;
        }

        #region 按键点击函数

        public void OnStartButtonClicked()
        {
            isPlay = true;
            roomStatus.Reset();
            roomStatus.isGaming = true;
            roomStatus.GroundsRemained = roomSetting.round;
        }


        public void OnSettingButtonClicked()
        {
            optionBehavior.Show();
        }

        public void OnExitButtonClicked()
        {
            isPlay = false;
            startButton.interactable = true;
            settingButton.interactable = true;
            roomStatus.Reset();
        }

        #endregion

        #region

        void newLevelSet()
        {
            //TODO: new level
        }

        void OpenNewLevel()
        {
            GameManager.Instance.CurrentPlayers = 
                players
                    .Where(p => p.isActiveAndEnabled)
                    .Select(p=>p.playerData)
                    .ToArray();
            //TODO: 地图选择
            GameManager.Instance.CurrentMapId = "grass_map";
            AsyncOperation ass = SceneManager.LoadSceneAsync("GamePlay", LoadSceneMode.Single);
        }

        void Timer()
        {
            //计数器关卡倒计时
            if (Timeleft >= 0)
            {
                Timeleft -= Time.deltaTime;
                TimeleftPercent = Timeleft / 10f;
            }

            Seconds = (int) Timeleft;

            //开始计时时随机选择关卡
            if (Timeleft > 9.9f)
            {
                newLevelSet();
            }

            //游戏结束判定
            if (Grounds == 0)
            {
                isPlay = false;
                roomStatus.isGaming = false;
                winnerPanel.Show();
            }

            //倒计时结束时打开新的关卡
            if (Timeleft < 0.1f)
            {
                if (Grounds != 0)
                {
                    roomStatus.GroundsRemained--;
                    OpenNewLevel();
                }
            }
        }

        #endregion
    }
}