﻿using System;

namespace GamePlay.Entity
{
    /// <summary>
    /// 玩家数据（关卡内）
    /// </summary>
    [Serializable]
    public class PlayerProperties
    {
        public int life;
        public int playerId;
        
        //Buff
        public int jumpInc;
        public int shield;
        public int speedInc;

    }
}