using System;
using Core;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Room
{
    public class PlayerTabBehaviour : MonoBehaviour
    {
        public RoomSetting roomSetting;

        public Image[] players = new Image[4];

        private void Awake()
        {
            if (players.Length != 4)
            {
                Debug.LogWarning("玩家图片数量不是4,可能会出问题！");
            }

            OnSettingChange(roomSetting);
            roomSetting.SettingChange += OnSettingChange;
        }

        private void OnSettingChange(RoomSetting setting)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i < setting.playerNumbers)
                {
                    players[i].gameObject.SetActive(true);
                    //TODO: OtherThings
                }
                else
                {
                    players[i].gameObject.SetActive(false);
                }
            }
        }
    }
}