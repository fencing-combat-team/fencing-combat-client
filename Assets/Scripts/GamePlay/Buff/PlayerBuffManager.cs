using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

namespace GamePlay.Buff
{
    public class PlayerBuffManager : WeakSingletonBehaviour<PlayerBuffManager>
    {
        private Dictionary<Entity.Buff, int> playerBuffMap = new Dictionary<Entity.Buff, int>();

        public void AddBuffToPlayer(int playerId, Entity.Buff buff)
        {
            buff.isUsed = true;
            playerBuffMap.Add(buff, playerId);
            buff.Add(playerId, this);
            BuffAdd?.Invoke(buff, playerBuffMap[buff]);
        }

        /// <summary>
        /// 获取一个玩家身上的buff
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public Entity.Buff[] GetPlayerBuff(int playerId)
        {
            return playerBuffMap.Where(p => p.Value == playerId).Select(p => p.Key).ToArray();
        }

        public event Action<Entity.Buff, int> BuffRemove;
        public event Action<Entity.Buff, int> BuffAdd;

        public void RemoveBuff(Entity.Buff buff)
        {
            BuffRemove?.Invoke(buff, playerBuffMap[buff]);
            buff.Remove(playerBuffMap[buff], this);
            playerBuffMap.Remove(buff);
        }
    }
}