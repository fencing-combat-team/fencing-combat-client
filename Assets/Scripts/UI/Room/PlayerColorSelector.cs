using System;
using System.Linq;
using Core;
using Enums;
using GamePlay.Data;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Room
{
    [RequireComponent(typeof(ToggleGroup))]
    public class PlayerColorSelector : MonoBehaviour
    {
        [HideInInspector]
        [SerializeField]
        private PlayerData playerData;
        public PlayerData PlayerData
        {
            get => playerData;
            set
            {
                playerData = value;
                NotifyPlayerDataChange();
            }
        }

        private void NotifyPlayerDataChange()
        {
            foreach (var data in toggleDatas)
            {
                data.toggle.group = _toggleGroup;
                data.toggle.isOn = data.color == playerData?.playerColor;
                data.toggle.onValueChanged.RemoveAllListeners();
                data.toggle.onValueChanged.AddListener(selected =>
                {
                    if (selected && playerData != null)
                    {
                        playerData.playerColor = data.color;
                    }
                });
            }
        }

        [Tooltip("玩家Id")]
        public int playerId;

        [Autowired]
        private ToggleGroup _toggleGroup;

        [Tooltip("玩家颜色选择框")]
        public ToggleData[] toggleDatas;

        private void Start()
        {
            this.InitComponents();
            
        }

    }

    [Serializable]
    public class ToggleData
    {
        public Toggle toggle;
        public PlayerColorEnum color;
    }
}