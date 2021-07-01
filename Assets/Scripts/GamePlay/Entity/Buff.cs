using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Entity
{
    /// <summary>
    /// 游戏增益
    /// </summary>
    [Serializable]
    public class Buff
    {
        public int buffId;       // buff编号
        public int buffTypeId;   // 类型编号
        public string buffName;  // 名称
        public float activeTime; // 持续时间
        public int activeCount;  // 使用次数
        public string info;      // 详情
        public bool isUsed;      // 是否被使用
        public float buffUnusedTime;  // 未被拾取时的在场时间
    }
}
