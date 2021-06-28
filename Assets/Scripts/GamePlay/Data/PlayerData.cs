using System;
using UnityEngine;

namespace GamePlay.Data
{
    
    [Serializable]
    public class PlayerData
    {
        public int playerId;
        public string playerName;
        [NonSerialized]
        public int score;
        [NonSerialized]
        public Color playerColor;
    }
}