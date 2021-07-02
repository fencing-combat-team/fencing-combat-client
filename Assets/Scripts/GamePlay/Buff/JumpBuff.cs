using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay.Buff
{
    /// <summary>
    /// ��Ծ����
    /// </summary>
    public class JumpBuff : Entity.Buff
    {
        public JumpBuff(int buffId, float activeTime, float buffUnusedTime)
        {
            this.buffId = buffId;
            this.buffTypeId = 3;
            this.activeTime = activeTime;
            this.activeCount = 0;
            this.buffName = "��Ծ����";
            this.info = "һ��ʱ����Ϊ�������5����Ծ��";
            this.isUsed = false;
            this.buffUnusedTime = buffUnusedTime;
        }

        public override void Add(int playerId, PlayerBuffManager buffManager)
        {
            PlayerInGameData.Instance.GetById(playerId).jumpInc += 5;
        }

        public override void Remove(int playerId, PlayerBuffManager buffManager)
        {
            PlayerInGameData.Instance.GetById(playerId).jumpInc -= 5;
        }
    }
}