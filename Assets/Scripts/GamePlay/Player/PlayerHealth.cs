using Core;
using GamePlay.Buff;
using GamePlay.Data;
using GamePlay.Entity;
using Managers;
using UnityEngine;
using Utils;
using System.Linq;
using Enums;

namespace GamePlay.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public Vector3 spawnPoint;

        [Autowired]
        private PlayerDataManager _dataManager;

        [Autowired]
        private PlayerAttack _attack;

        // Start is called before the first frame update
        void Start()
        {
            this.InitComponents();
        }

        // Update is called once per frame
        void Update()
        {
            if (_dataManager.Properties.life <= 0)
            {
                PlayerInGameData.Instance.OnPlayerDead(_dataManager.PlayerId);
                Destroy(this.gameObject);
            }
        }

        public void Die()
        {
            PlayerWeapons.Instance.SpawnWeapon(this.transform.position, _attack._weapon.Id);
            if (_dataManager.Properties.shield > 0)
            {
                _dataManager.Properties.shield--;
                Entity.Buff buff = PlayerBuffManager.Instance.GetPlayerBuff(_dataManager.Properties.playerId).Where(b => b.buffTypeId == 2).FirstOrDefault();
                buff.activeCount--;
            }
            else
            {
                _dataManager.Properties.life--;
                transform.position = spawnPoint;
            }
            PlayerWeapons.Instance.SwitchPlayerWeapon(this.gameObject, WeaponTypeEnum.Sword, true);

        }

        public void EdgeDie()
        {
            if (_dataManager.Properties.shield > 0)
            {
                _dataManager.Properties.shield = 0;
                Entity.Buff buff = PlayerBuffManager.Instance.GetPlayerBuff(_dataManager.Properties.playerId).Where(b => b.buffTypeId == 2).FirstOrDefault();
                buff.activeCount = 0;
            }

            _dataManager.Properties.life--;
            transform.position = spawnPoint;
        }
    }
}