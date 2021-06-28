using System;
using System.Net.Mime;
using Core;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Room
{
    public class RoomSettingTextBehaviour : MonoBehaviour
    {
        public RoomSetting roomSetting;

        [Autowired]
        private Text text;

        private void Awake()
        {
            this.InitComponents();
            OnSettingChange(roomSetting);
            roomSetting.SettingChange += OnSettingChange;
        }

        private void OnSettingChange(RoomSetting setting)
        {
            text.text =
                $"需要进行的关卡数：{setting.round}\n" +
                $"每局游戏玩家的生命数：{setting.lives}\n" +
                $"玩家复活时间：{setting.recoveryTime}\n" +
                $"n是否开启道具";
        }
    }
}