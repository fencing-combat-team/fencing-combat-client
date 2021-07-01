using System;
using System.Net.Mime;
using Core;
using Managers;
using UI.Data;
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
            roomSetting.SettingChange += OnSettingChange;
        }

        private void Start()
        {
            Refresh();
        }

        public void Refresh()
        {
            if (GameManager.Instance.RoomStatus.isGaming)
            {
                text.text =
                    $"需要进行的关卡数：{roomSetting.round}\n" +
                    $"剩余关卡数：{GameManager.Instance.RoomStatus.GroundsRemained}\n" +
                    $"每局游戏玩家的生命数：{roomSetting.lives}\n" +
                    $"玩家复活时间：{roomSetting.recoveryTime}";
            }
            else
            {
                
                text.text =
                    $"需要进行的关卡数：{roomSetting.round}\n" +
                    $"每局游戏玩家的生命数：{roomSetting.lives}\n" +
                    $"玩家复活时间：{roomSetting.recoveryTime}";
            }
        }

        private void OnSettingChange(RoomSetting setting)
        {
            Refresh();
        }
    }
}