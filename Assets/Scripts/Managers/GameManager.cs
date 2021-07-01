using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using GamePlay.Data;
using GamePlay.Entity;
using UI.Data;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        void Update()
        {

        }

        public void OnGameOver(List<int> failedPlayers)
        {
            for (var i = 0; i < failedPlayers.Count; i++)
            {
                var player = CurrentPlayers.First(p => p.playerId == failedPlayers[i]);
                player.score += i;
            }

            var winner = CurrentPlayers.Where(p => !failedPlayers.Contains(p.playerId)).First();
            winner.score += failedPlayers.Count;
            
            
            //TODO: 发点通知啥的

            SceneManager.LoadSceneAsync("Scenes/PlayerRoom/Room", LoadSceneMode.Single);
        }

        private void Awake()
        {
            RoomStatus = UnityEngine.Resources.Load<RoomStatus>("Data/Roomstatu");
            PlayerRoomData = UnityEngine.Resources.Load<PlayerRoomData>("Data/PlayerRoomData");
        }

        public RoomStatus RoomStatus { get; set; }
        public PlayerRoomData PlayerRoomData { get; set; }

        public string CurrentMapId { get; set; }
        public PlayerData[] CurrentPlayers { get; set; }
    }
}
