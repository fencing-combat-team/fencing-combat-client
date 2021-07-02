using System;
using System.Collections;
using System.Linq;
using GamePlay.Data;
using Managers;
using UI.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


// 这是房间主要界面的控制类


namespace UI.Room
{
    public class RoomBasicBeheavior : ViewPanelBehaviourBase
    {
        #region 可设置变量

        public RoomOptionBehavior optionBehavior;
        public WinnerPanel winnerPanel;
        public LevelDefinitionData levelDefinitionData;

        public Text levelname;
        public Text levelmessage;
        public Image levelPic;
        public Text time;
        public Text ground;

        public Image image;

        public Button startButton;
        public Button exitButton;
        public Button settingButton;

        #endregion


        [Tooltip("房间设置")]
        public RoomSetting roomSetting;


        #region 单例变量

        bool isPlay = false;

        private float Timeleft = 10;

        //外部会引用到的变量
        public float TimeleftPercent = 1;
        public int Seconds = 10;
        public int Grounds = 3;

        #endregion

        private PlayerDataShower[] players;
        private RoomSettingTextBehaviour _roomSettingTextBehaviour;


        // Start is called before the first frame update
        void Start()
        {
            
            Random.InitState((int) DateTime.Now.Ticks);

            //初始化颜色选择器
            foreach (var colorSelector in GameObject.Find("PlayerPanel").GetComponentsInChildren<PlayerColorSelector>())
            {
                colorSelector.PlayerData = GameManager.Instance.PlayerRoomData.GetById(colorSelector.playerId);
            }

            players = GameObject.Find("PlayerPanel").GetComponentsInChildren<PlayerDataShower>();
            foreach (var dataShower in players)
            {
                dataShower.playerData = GameManager.Instance.PlayerRoomData.GetById(dataShower.playerId);
            }

            _roomSettingTextBehaviour = GetComponentInChildren<RoomSettingTextBehaviour>();
            
            if (GameManager.Instance.RoomStatus.isGaming)
            {
                isPlay = true;
                Grounds = GameManager.Instance.RoomStatus.GroundsRemained;
                
                StartCoroutine(nameof(NewLevelSet));
            }
        }

        // Update is called once per frame
        void Update()
        {
            //计时以及计算局数部分
            if (isPlay)
            {
                startButton.interactable = false;
                settingButton.interactable = false;
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
        }

        #region 按键点击函数

        public void OnStartButtonClicked()
        {
            isPlay = true;
            GameManager.Instance.RoomStatus.Reset();
            GameManager.Instance.RoomStatus.isGaming = true;
            GameManager.Instance.RoomStatus.GroundsRemained = roomSetting.round;
            StartCoroutine(nameof(NewLevelSet));
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
            GameManager.Instance.RoomStatus.Reset();
            StopCoroutine(nameof(NewLevelSet));
            StopCoroutine(nameof(Timer));
        }

        #endregion

        private int mapIndex = 0;

        #region

        IEnumerator NewLevelSet()
        {
            
            //游戏结束判定
            if (Grounds == 0)
            {
                isPlay = false;
                GameManager.Instance.RoomStatus.isGaming = false;
                winnerPanel.Show();
                winnerPanel.GetComponent<WinnerPanel>().GetWinner();
            }
            else
            {
                int random = Random.Range(0, levelDefinitionData.maps.Length);
                int index = random;
                float waitTime = 0.02f;
                for (int i = 0; i < 20; i++)
                {
                    index = (random + i) % levelDefinitionData.maps.Length;
                    var map = levelDefinitionData.maps[index];
                    levelmessage.text = map.description;
                    levelname.text = map.title;
                    levelPic.sprite = map.shortcut;
                    yield return new WaitForSeconds(waitTime);

                    waitTime *= 1.2f;
                }

                mapIndex = index;

                StartCoroutine(nameof(Timer));
            }
        }

        void OpenNewLevel()
        {
            GameManager.Instance.CurrentPlayers =
                players
                    .Where(p => p.isActiveAndEnabled)
                    .Select(p => p.playerData)
                    .ToArray();

            PlayerInGameData.Instance.ResetFor(
                GameManager.Instance.CurrentPlayers.Length,
                roomSetting.lives);

            GameManager.Instance.CurrentMapId = levelDefinitionData.maps[mapIndex].mapId;
            SceneManager.LoadSceneAsync("GamePlay", LoadSceneMode.Single);
        }

        IEnumerator Timer()
        {
            while (true)
            {
                //计数器关卡倒计时
                if (Timeleft >= 0)
                {
                    Timeleft -= Time.deltaTime;
                    TimeleftPercent = Timeleft / 10f;
                }

                Seconds = (int) Timeleft;

                //倒计时结束时打开新的关卡
                if (Timeleft < 0.1f)
                {
                    GameManager.Instance.RoomStatus.GroundsRemained--;
                    OpenNewLevel();
                    break;
                }

                yield return null;
            }
        }

        #endregion
    }
}