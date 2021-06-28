using System;
using System.Linq;
using Core;
using GamePlay.Data;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Room
{
    [RequireComponent(typeof(ToggleGroup))]
    public class PlayerColorSelector : MonoBehaviour
    {
        [NonSerialized]
        public PlayerData playerData;

        [Tooltip("玩家Id")]
        public int playerId;

        [Autowired]
        private ToggleGroup _toggleGroup;

        private Toggle[] _toggles;
        private void Start()
        {
            this.InitComponents();
            _toggles = GetComponentsInChildren<Toggle>();

            foreach (var toggle in _toggles)
            {
                toggle.group = _toggleGroup;
                toggle.onValueChanged.AddListener(selected =>
                {
                    if (selected && playerData != null)
                    {
                        playerData.playerColor = toggle.colors.normalColor;
                    }
                });
            }
        }

    }
}