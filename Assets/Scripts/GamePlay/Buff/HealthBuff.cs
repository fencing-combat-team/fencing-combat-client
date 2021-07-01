using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Buff
{
    /// <summary>
    /// 生命恢复
    /// </summary>
    public class HealthBuff : Entity.Buff
    {
        public HealthBuff(int buffId, float buffUnusedTime)
        {
            this.buffId = buffId;
            this.buffTypeId = 0;
            this.activeTime = 0;
            this.activeCount = 0;
            this.buffName = "生命恢复";
            this.info = "为玩家恢复1点生命值";
            this.isUsed = false;
            this.buffUnusedTime = buffUnusedTime;
        }
    }
}
