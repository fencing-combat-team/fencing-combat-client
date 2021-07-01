using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Buff
{
    /// <summary>
    /// �ٶ�����
    /// </summary>
    public class SpeedBuff : Entity.Buff
    {
        public SpeedBuff(int buffId, float activeTime, float buffUnusedTime)
        {
            this.buffId = buffId;
            this.buffTypeId = 1;
            this.activeTime = activeTime;
            this.activeCount = 0;
            this.buffName = "�ٶ�����";
            this.info = "һ��ʱ����Ϊ������5���ٶ�";
            this.isUsed = false;
            this.buffUnusedTime = buffUnusedTime;
        }
    }
}
