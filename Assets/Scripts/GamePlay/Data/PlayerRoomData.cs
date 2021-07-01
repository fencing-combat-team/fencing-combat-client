using System;
using UnityEngine;
using System.Linq;
using GamePlay.Entity;
using UnityEngine.UI;

namespace GamePlay.Data
{

    [CreateAssetMenu(fileName = "New PlayerRoomData", menuName = "ScriptableObjects/Player/PlayerRoomData")]
    public class PlayerRoomData : ScriptableObject
    {
        public PlayerData[] players = new PlayerData[4];
        
        void OnValidate()
        {
            if (players.Length != 4)
            {
                var old = players;
                players = new PlayerData[4];
                Array.Copy(old, players, Math.Min(4, old.Length));
            }
        }

        public PlayerData GetById(int playerId)
        {
            return players.First(p => p.playerId == playerId);
        }
    }
}