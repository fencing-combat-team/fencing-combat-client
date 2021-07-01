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
            _dataManager.Properties.life--;
            transform.position = spawnPoint;
        }
    }
}
