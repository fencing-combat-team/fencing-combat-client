using System;
using GamePlay.Data;
using GamePlay.Entity;
using UnityEngine;

namespace GamePlay.Player
{
    public class PlayerDataManager : MonoBehaviour
    {
        [HideInInspector]
        public PlayerData playerData;
        [SerializeField]
        private int playerId;
        public int PlayerId
        {
            get => playerId;
            set
            {
                playerId = value;
                InitData();
            }
        }
        
        
        [NonSerialized]
        private PlayerProperties _properties;

        public PlayerProperties Properties => _properties ?? new PlayerProperties();

        private void InitData()
        {
            _properties = PlayerInGameData.Instance.GetById(this.playerId);
        }
    }
}