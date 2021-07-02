using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay.Buff
{
    /// <summary>
    /// ���ܱ���
    /// </summary>
    public class ShieldBuff : Entity.Buff
    {
        public ShieldBuff(int buffId, int activeCount, float buffUnusedTime)
        {
            this.buffId = buffId;
            this.buffTypeId = 2;
            this.activeTime = 0;
            this.activeCount = activeCount;
            this.buffName = "���ܱ���";
            this.info = "Ϊ������һ���ܹ�����3�ι����Ļ���";
            this.isUsed = false;
            this.buffUnusedTime = buffUnusedTime;
        }

        public override void Add(int playerId, PlayerBuffManager buffManager)
        {
            PlayerInGameData.Instance.GetById(playerId).shield += this.activeCount;
        }

        public override void Remove(int playerId, PlayerBuffManager buffManager)
        {
            //PlayerInGameData.Instance.GetById(playerId).shield = 0;
        }
    }
}