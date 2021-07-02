using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Buff;
using UnityEngine;

namespace GamePlay.Entity
{
    /// <summary>
    /// ��Ϸ����
    /// </summary>
    public abstract class Buff
    {
        public int buffId;       // buff���
        public int buffTypeId;   // ���ͱ��
        public string buffName;  // ����
        public float activeTime; // ����ʱ��
        public int activeCount;  // ʹ�ô���
        public string info;      // ����
        public bool isUsed;      // �Ƿ�ʹ��
        public float buffUnusedTime;  // δ��ʰȡʱ���ڳ�ʱ��
        public abstract void Add(int playerId, PlayerBuffManager buffManager);
        public abstract void Remove(int playerId, PlayerBuffManager buffManager);
    }
}
