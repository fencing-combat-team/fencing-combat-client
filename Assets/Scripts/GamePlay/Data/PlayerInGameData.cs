using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Core;
using GamePlay.Entity;
using UnityEngine;

namespace GamePlay.Data
{
    public class PlayerInGameData : Singleton<PlayerInGameData>
    {
        public PlayerProperties[] Properties { get; private set; }

        public void ResetFor(int playerNum)
        {
            Properties = new PlayerProperties[playerNum];
            for (var i = 0; i < Properties.Length; i++)
            {
                Properties[i] = new PlayerProperties() {playerId = i + 1};
            }
            Reset?.Invoke();
        }

        public event Action Reset;

        public PlayerProperties GetById(int playerId)
        {
            return Properties.First(p => p.playerId == playerId);
        }
    }
}