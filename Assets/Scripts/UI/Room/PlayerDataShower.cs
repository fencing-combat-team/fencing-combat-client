using System;
using System.Net.Mime;
using GamePlay.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Room
{
    public class PlayerDataShower : MonoBehaviour
    {
        [HideInInspector]
        public PlayerData playerData;


        public Text playerName;
        public Text score;

        private void Update()
        {
            if (playerData != null)
            {
                playerName.text = playerData.playerName;
                score.text = playerData.score.ToString();
            }
        }


        [Tooltip("玩家Id")]
        public int playerId;
    }
}