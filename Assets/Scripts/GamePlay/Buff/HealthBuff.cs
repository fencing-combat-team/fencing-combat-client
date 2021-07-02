using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay.Buff
{
    /// <summary>
    /// �����ָ�
    /// </summary>
    public class HealthBuff : Entity.Buff
    {
        public HealthBuff(int buffId, float buffUnusedTime)
        {
            this.buffId = buffId;
            this.buffTypeId = 0;
            this.activeTime = 0;
            this.activeCount = 0;
            this.buffName = "�����ָ�";
            this.info = "Ϊ��һָ�1������ֵ";
            this.isUsed = false;
            this.buffUnusedTime = buffUnusedTime;
        }

        public override void Add(int playerId, PlayerBuffManager buffManager)
        {
            PlayerInGameData.Instance.GetById(playerId).life++;
        }

        public override void Remove(int playerId, PlayerBuffManager buffManager)
        {
            
        }
    }
}
