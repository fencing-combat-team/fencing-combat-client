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
        private int buffTypeCount = 4; // buff类型数
        private float buffUnusedTime = 20; // buff未被拾取时的持续在场时间
        private float buffDefaultActiveTime = 10; // buff默认持续时间
        private int buffDefaultActiveCount = 3; // buff默认使用次数
        private float timePerInitBuff = 10; // 生成buff的间隔时间

        private float initTimer; // 初始化计时器
        private float updateTimer; // 更新计时器
        private int buffCounter; // buff计数器（用于设置id）

        private PlayerData[] players; // 玩家
        private List<Buff> buffList; // buff列表
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
            // 每段时间随机生成buff
            initTimer -= Time.deltaTime;
            if (initTimer <= 0)
            {
                initTimer = timePerInitBuff;
                //随机Pick一个buff
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


            // 对buff时间进行更新
            updateTimer -= Time.deltaTime;
            if (updateTimer <= 0)
            {
                updateTimer = 1;
                UpdateBuff();
            }
        }

        private void InitBuffManager() // 初始化Manager
        {
            initTimer = timePerInitBuff;
            updateTimer = 1;
            buffCounter = 0;
            buffList = new List<Buff>(); // buff列表
            buffObjects = new Dictionary<int, GameObject>();

            players = GameManager.Instance.CurrentPlayers;
            PlayerBuffManager.Instance.BuffRemove += (buff, p) =>
            {
                buffObjects?.Remove(buff.buffId);
                buffList?.Remove(buff);
            };
        }

        private void InitBuff(BuffTypeEnum typeid, Vector3 pos) // 生成一个buff
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

        private void UpdateBuff() // 更新buff
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

        private void WithdrawBuff(Buff buff) // 撤销buff
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