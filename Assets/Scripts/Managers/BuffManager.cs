using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Entity;
using GamePlay.Buff;
using System.Linq;
using Enums;
using GamePlay.Data;
using Random = UnityEngine.Random;

namespace Managers
{
    public class BuffManager : MonoBehaviour
    {
        private int buffTypeCount = 4; // buff������
        private float buffUnusedTime = 20; // buffδ��ʰȡʱ�ĳ����ڳ�ʱ��
        private float buffDefaultActiveTime = 10; // buffĬ�ϳ���ʱ��
        private int buffDefaultActiveCount = 3; // buffĬ��ʹ�ô���
        private float timePerInitBuff = 10; // ����buff�ļ��ʱ��

        private float initTimer; // ��ʼ����ʱ��
        private float updateTimer; // ���¼�ʱ��
        private int buffCounter; // buff����������������id��

        private PlayerData[] players; // ���
        private List<Buff> buffList; // buff�б�
        private Dictionary<int, GameObject> buffObjects;

        public Map map;
        public GameObject buffPrefab;


        void Start()
        {
            InitBuffManager();
            Random.InitState((int) DateTime.Now.Ticks);
        }

        void Update()
        {
            // ÿ��ʱ���������buff
            initTimer -= Time.deltaTime;
            if (initTimer <= 0)
            {
                initTimer = timePerInitBuff;
                //���Pickһ��buff
                var sum = map.buffs.Select(buff => buff.spawnChance).Sum();
                var rand = Random.Range(0, sum);

                var currentSum = 0f;
                foreach (var buff in map.buffs)
                {
                    var chance = buff.spawnChance;
                    currentSum += chance;
                    if (currentSum > rand)
                    {
                        var pos = buff.possibleSpawnPoints;
                        InitBuff(buff.buffId, pos[Random.Range(0, pos.Length)]);
                        break;
                    }
                }
            }


            // ��buffʱ����и���
            updateTimer -= Time.deltaTime;
            if (updateTimer <= 0)
            {
                updateTimer = 1;
                UpdateBuff();
            }
        }

        private void InitBuffManager() // ��ʼ��Manager
        {
            initTimer = timePerInitBuff;
            updateTimer = 1;
            buffCounter = 0;
            buffList = new List<Buff>(); // buff�б�
            buffObjects = new Dictionary<int, GameObject>();

            players = GameManager.Instance.CurrentPlayers;
            PlayerBuffManager.Instance.BuffRemove += (buff, p) =>
            {
                buffObjects?.Remove(buff.buffId);
                buffList?.Remove(buff);
            };
        }

        private void InitBuff(BuffTypeEnum typeid, Vector3 pos) // ����һ��buff
        {
            Buff newBuff;
            switch (typeid)
            {
                case BuffTypeEnum.HealthBuff:
                    newBuff = new HealthBuff(buffCounter, buffUnusedTime);
                    break;
                case BuffTypeEnum.SpeedBuff:
                    newBuff = new SpeedBuff(buffCounter, buffDefaultActiveTime, buffUnusedTime);
                    break;
                case BuffTypeEnum.ShieldBuff:
                    newBuff = new ShieldBuff(buffCounter, buffDefaultActiveCount, buffUnusedTime);
                    break;
                case BuffTypeEnum.JumpBuff:
                    newBuff = new JumpBuff(buffCounter, buffDefaultActiveTime, buffUnusedTime);
                    break;
                default: return;
            }

            buffCounter++;
            buffList.Add(newBuff);
            var obj = Instantiate(buffPrefab);
            obj.GetComponent<BuffBehaviour>().SetBuff(newBuff);
            obj.transform.position = pos;
            buffObjects.Add(newBuff.buffId, obj);
        }

        private void UpdateBuff() // ����buff
        {
            List<Buff> unusedBuffs = buffList.Where(b => b.isUsed == false).ToList();
            List<Buff> usedBuffs = buffList.Where(b => b.isUsed == true).ToList();

            foreach (var buff in unusedBuffs)
            {
                buff.buffUnusedTime--;
                if (buff.buffUnusedTime <= 0)
                    WithdrawBuff(buff);
            }

            foreach (var buff in usedBuffs)
            {
                switch (buff.buffTypeId)
                {
                    case 1:
                    case 3:
                        buff.activeTime--;
                        if (buff.activeTime <= 0)
                            WithdrawBuff(buff);
                        break;
                    default: break;
                }
            }
        }

        private void WithdrawBuff(Buff buff) // ����buff
        {
            if (buff.isUsed == false)
            {
                Destroy(buffObjects[buff.buffId]);
            }
            else
            {
                PlayerBuffManager.Instance.RemoveBuff(buff);
            }

            buffObjects.Remove(buff.buffId);
            buffList.Remove(buff);
        }
    }
}