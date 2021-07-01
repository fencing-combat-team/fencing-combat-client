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
        private int buffTypeCount = 4;            // buff类型数
        private float buffUnusedTime = 20;        // buff未被拾取时的持续在场时间
        private float buffDefaultActiveTime = 10; // buff默认持续时间
        private int buffDefaultActiveCount = 3;   // buff默认使用次数
        private float timePerInitBuff = 10;       // 生成buff的间隔时间

        private float initTimer;      // 初始化计时器
        private float updateTimer;    // 更新计时器
        private int buffCounter;      // buff计数器（用于设置id）

        public PlayerData[] players;  // 玩家
        public string mapId;          // 根据地图id设置产生buff道具的位置
        public Vector3[] position;    // 产生buff道具的位置
        public List<Buff> buffList;   // buff列表

        void Start()
        {
            InitBuffManager();
        }

        void Update()
        {
            // 每段时间随机生成buff
            initTimer -= Time.deltaTime;
            if(initTimer<=0)
            {
                initTimer = timePerInitBuff;
                InitBuff(Random.Range(0, buffTypeCount));
            }


            // 对buff时间进行更新
            updateTimer -= Time.deltaTime;
            if(updateTimer<=0)
            {
                updateTimer = 1;
                UpdateBuff();
            }


        }

        private void InitBuffManager()     // 初始化Manager
        {
            initTimer = timePerInitBuff;
            updateTimer = 1;
            buffCounter = 0;

            players = GameManager.Instance.CurrentPlayers;
            mapId = GameManager.Instance.CurrentMapId;
            switch (mapId)
            {
                case "sketch_map":
                    //// position添加坐标!!!
                    break;
                case "color_map":
                    //// position添加坐标!!!
                    break;
                case "pixel_map":
                    //// position添加坐标!!!
                    break;
                case "realworld_map":
                    //// position添加坐标!!!
                    break;
                default:print("Init Buff Wrong!"); break;
            }
        }

        private void InitBuff(int typeid)  // 生成一个buff
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

        private void UpdateBuff()    // 更新buff
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

        private void WithdrawBuff(Buff buff)   // 撤销buff
        {
            if(buff.isUsed == false)
            {
                ////  从地图上撤销！！！
            }
            else
            {
                RemoveBuffFromPlayer();
            }

            buffList.Remove(buff);
        }


        public void AddBuffToPlayer(/*参数*/)  // 给玩家添加buff
        {

        }
        public void RemoveBuffFromPlayer(/*参数*/) // 从玩家上取消buff
        {

        }
    }
}
