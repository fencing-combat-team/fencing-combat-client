using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Buff
{
    /// <summary>
    /// 速度提升
    /// </summary>
    public class SpeedBuff : Entity.Buff
    {
        public SpeedBuff(int buffId, float activeTime, float buffUnusedTime)
        {
            this.buffId = buffId;
            this.buffTypeId = 1;
            this.activeTime = activeTime;
            this.activeCount = 0;
            this.buffName = "速度提升";
            this.info = "一定时间内为玩家提高5点速度";
            this.isUsed = false;
            this.buffUnusedTime = buffUnusedTime;
        }
    }
}
