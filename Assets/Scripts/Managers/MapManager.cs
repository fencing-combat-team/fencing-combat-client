using System;
using System.Collections.Generic;
using Core;
using Enums;
using GamePlay.Camera;
using GamePlay.Data;
using GamePlay.Entity;
using GamePlay.Player;
using UI.Data;
using UnityEngine;
using Utils;

namespace Managers
{
    public class MapManager : MonoBehaviour
    {
        public LevelDefinitionData levelDefinition;
        public GameObject playerPrefab;
        public PlayerColors colors;

        [Autowired("/Main Camera")]
        private AutoCamera _autoCamera;
        private void Start()
        {
            //TODO: 这个放到主菜单
            GameManager.Instance.CurrentMapId = "grass_map";
            GameManager.Instance.CurrentPlayers = new[]
            {
                new PlayerData()
                {
                    playerId = 1,
                    playerColor = PlayerColorEnum.Blue,
                    playerName = "Player1"
                },
                new PlayerData()
                {

                    playerId = 2,
                    playerColor = PlayerColorEnum.Red,
                    playerName = "Player2"
                },
            };
            
            this.InitComponents();
            InitMap();
        }

        private void InitMap()
        {
            var mapId = GameManager.Instance.CurrentMapId;
            var map = levelDefinition.GetMapById(mapId);
            
            //碰撞
            var colliders = new List<BoxCollider2D>();
            foreach (var groundPrefab in map.groundColliderPrefabs)
            {
                var ground = Instantiate(groundPrefab);
                colliders.AddRange(ground.GetComponentsInChildren<BoxCollider2D>());
            }


            int spawnIndex = 0;
            //玩家
            foreach (var player in GameManager.Instance.CurrentPlayers)
            {
                var playerObj = Instantiate(playerPrefab);
                var playerData = playerObj.GetComponent<PlayerDataManager>();
                var playerInteration = playerObj.GetComponent<PlayerInteration>();
                var playerRender = playerObj.GetComponent<SpriteRenderer>();
                playerRender.color = colors[player.playerColor];
                playerData.playerData = player;
                playerData.playerId = player.playerId;
                playerInteration.ground = colliders.ToArray();

                if (spawnIndex >= map.spawnPoints.Length)
                {
                    spawnIndex = 0;
                }

                var pos = map.spawnPoints[spawnIndex++];
                playerObj.transform.position = new Vector3(pos.x, pos.y);
            }
            
            
            //背景
            var bg = Instantiate(map.backgroundPrefab);
            _autoCamera.background = bg.GetComponent<SpriteRenderer>();
            _autoCamera.ResetBackground();
            

        }
    }
}