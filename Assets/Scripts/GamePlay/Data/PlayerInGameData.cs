using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Core;
using GamePlay.Entity;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace GamePlay.Data
{
    public class PlayerInGameData : SingletonBehaviour<PlayerInGameData>
    {
        public PlayerInGameData()
        {
            ResetFor(0, 0);
        }

        public PlayerProperties[] Properties { get; private set; }

        private List<int> _failedPlayers;

        public void OnPlayerDead(int playerId)
        {
            _failedPlayers.Add(playerId);
            if (_failedPlayers.Count >= Properties.Length - 1)
            {
                GameManager.Instance.OnGameOver(_failedPlayers);
            }
        }

        public void ResetFor(int playerNum, int playerLife)
        {
            Properties = new PlayerProperties[playerNum];
            _failedPlayers = new List<int>();
            for (var i = 0; i < Properties.Length; i++)
            {
                Properties[i] = new PlayerProperties() {playerId = i + 1, life = playerLife};
            }

            Reset.Invoke();
        }

        public UnityEvent Reset = new UnityEvent();

        public PlayerProperties GetById(int playerId)
        {
            return Properties.First(p => p.playerId == playerId);
        }
    }
}