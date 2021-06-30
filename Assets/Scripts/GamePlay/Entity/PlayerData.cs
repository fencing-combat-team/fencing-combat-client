using System;
using Enums;

namespace GamePlay.Entity
{
    /// <summary>
    /// 玩家数据（关卡外）
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public int playerId;
        public string playerName;
        public int score;
        public PlayerColorEnum playerColor;
    }


    
}