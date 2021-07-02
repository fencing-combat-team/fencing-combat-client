using Core;
using GamePlay.Data;
using GamePlay.Entity;
using Managers;
using UnityEngine;
using Utils;

namespace GamePlay.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public Vector3 spawnPoint;

        [Autowired]
        private PlayerDataManager _dataManager;
        [Autowired]
        private PlayerWeapons _weapon;

        // Start is called before the first frame update
        void Start()
        {
            this.InitComponents();
        }

        // Update is called once per frame
        void Update()
        {
            if (_dataManager.Properties.life < 0)
            {
                PlayerInGameData.Instance.OnPlayerDead(_dataManager.PlayerId);
                Destroy(this.gameObject);
            }
        }

        public void Die()
        {
            if (_dataManager.Properties.shield > 0)
            {
                _dataManager.Properties.shield--;
            }
            else
            {
                _dataManager.Properties.life--;
                transform.position = spawnPoint;
            }
            _weapon.InitWeapon(this.transform.position, this.GetComponent<PlayerAttack>()._weapon.Id);
            this.GetComponent<PlayerAttack>()._weapon = new Sword();
        }

        public void EdgeDie()
        {
            if (_dataManager.Properties.shield > 0)
            {
                _dataManager.Properties.shield = 0;
            }

            _dataManager.Properties.life--;
            transform.position = spawnPoint;
        }
    }
}