using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Entity;
using GamePlay.Buff;
using System.Linq;

namespace Managers
{
    public class BuffManager : MonoBehaviour
    {
        private int buffTypeCount = 4;            // buff������
        private float buffUnusedTime = 20;        // buffδ��ʰȡʱ�ĳ����ڳ�ʱ��
        private float buffDefaultActiveTime = 10; // buffĬ�ϳ���ʱ��
        private int buffDefaultActiveCount = 3;   // buffĬ��ʹ�ô���
        private float timePerInitBuff = 10;       // ����buff�ļ��ʱ��

        private float initTimer;      // ��ʼ����ʱ��
        private float updateTimer;    // ���¼�ʱ��
        private int buffCounter;      // buff����������������id��

        public PlayerData[] players;  // ���
        public string mapId;          // ���ݵ�ͼid���ò���buff���ߵ�λ��
        public Vector3[] position;    // ����buff���ߵ�λ��
        public List<Buff> buffList;   // buff�б�

        void Start()
        {
            InitBuffManager();
        }

        void Update()
        {
            // ÿ��ʱ���������buff
            initTimer -= Time.deltaTime;
            if(initTimer<=0)
            {
                initTimer = timePerInitBuff;
                InitBuff(Random.Range(0, buffTypeCount));
            }


            // ��buffʱ����и���
            updateTimer -= Time.deltaTime;
            if(updateTimer<=0)
            {
                updateTimer = 1;
                UpdateBuff();
            }


        }

        private void InitBuffManager()     // ��ʼ��Manager
        {
            initTimer = timePerInitBuff;
            updateTimer = 1;
            buffCounter = 0;

            players = GameManager.Instance.CurrentPlayers;
            mapId = GameManager.Instance.CurrentMapId;
            switch (mapId)
            {
                case "sketch_map":
                    //// position�������!!!
                    break;
                case "color_map":
                    //// position�������!!!
                    break;
                case "pixel_map":
                    //// position�������!!!
                    break;
                case "realworld_map":
                    //// position�������!!!
                    break;
                default:print("Init Buff Wrong!"); break;
            }
        }

        private void InitBuff(int typeid)  // ����һ��buff
        {
            Buff newBuff;
            switch (typeid)
            {
                case 0: newBuff = new HealthBuff(buffCounter,buffUnusedTime); break;
                case 1: newBuff = new SpeedBuff(buffCounter, buffDefaultActiveTime, buffUnusedTime); break;
                case 2: newBuff = new ShieldBuff(buffCounter, buffDefaultActiveCount, buffUnusedTime); break;
                case 3: newBuff = new JumpBuff(buffCounter, buffDefaultActiveTime, buffUnusedTime); break;
                default: return;
            }
            buffCounter++;
            buffList.Add(newBuff);
        }

        private void UpdateBuff()    // ����buff
        {
            List<Buff> unusedBuffs = buffList.Where(b => b.isUsed == false).ToList();
            List<Buff> usedBuffs = buffList.Where(b => b.isUsed == true).ToList();

            foreach(var buff in unusedBuffs)
            {
                buff.buffUnusedTime--;
                if (buff.buffUnusedTime <= 0)
                    WithdrawBuff(buff);
            }

            foreach(var buff in usedBuffs)
            {
                switch(buff.buffTypeId)
                {
                    case 1:
                    case 3:
                        buff.activeTime--;
                        if (buff.activeTime <= 0)
                            WithdrawBuff(buff);
                        break;
                    default:break;
                }
            }
        }

        private void WithdrawBuff(Buff buff)   // ����buff
        {
            if(buff.isUsed == false)
            {
                ////  �ӵ�ͼ�ϳ���������
            }
            else
            {
                RemoveBuffFromPlayer();
            }

            buffList.Remove(buff);
        }


        public void AddBuffToPlayer(/*����*/)  // ��������buff
        {

        }
        public void RemoveBuffFromPlayer(/*����*/) // �������ȡ��buff
        {

        }
    }
}
