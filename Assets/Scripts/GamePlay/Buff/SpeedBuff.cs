using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
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

        public override void Add(int playerId, PlayerBuffManager buffManager)
        {
            PlayerInGameData.Instance.GetById(playerId).speedInc += 5;
        }

        public override void Remove(int playerId, PlayerBuffManager buffManager)
        {
            PlayerInGameData.Instance.GetById(playerId).speedInc -= 5;
        }
    }
}
