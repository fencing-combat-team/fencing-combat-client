using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Entity
{
    /// <summary>
    /// ��Ϸ����
    /// </summary>
    [Serializable]
    public class Buff
    {
        public int buffId;       // buff���
        public int buffTypeId;   // ���ͱ��
        public string buffName;  // ����
        public float activeTime; // ����ʱ��
        public int activeCount;  // ʹ�ô���
        public string info;      // ����
        public bool isUsed;      // �Ƿ�ʹ��
        public float buffUnusedTime;  // δ��ʰȡʱ���ڳ�ʱ��
    }
}
