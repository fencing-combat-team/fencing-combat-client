using System;
using Enums;
using UnityEngine;

namespace GamePlay.Data
{
    
    [Serializable]
    public class PlayerData
    {
        public int playerId;
        public string playerName;
        public int score;
        public PlayerColorEnum playerColor;
    }


    [Serializable]
    public class PlayerColorPair
    {
        public PlayerColorEnum colorEnum;
        public Color color;
    }
}