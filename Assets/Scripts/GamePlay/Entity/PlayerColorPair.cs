using System;
using Enums;
using UnityEngine;

namespace GamePlay.Entity
{
    /// <summary>
    /// 玩家颜色数据
    /// </summary>
    [Serializable]
    public class PlayerColorPair
    {
        public PlayerColorEnum colorEnum;
        public Color color;
    }
}