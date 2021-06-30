using System;
using System.Collections.Generic;
using Core;
using Enums;
using GamePlay.Camera;
using GamePlay.Data;
using GamePlay.Entity;
using GamePlay.Player;
using UI.Data;
using UnityEditor;
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
            this.InitComponents();
            InitMap();
        }

        private void InitMap()
        {
            
            var mapId = GameManager.Instance.CurrentMapId;
            var map = levelDefinition.GetMapById(mapId);

            var players = new List<GameObject>(GameManager.Instance.CurrentPlayers.Length);
            int spawnIndex = 0;
            //玩家
            foreach (var player in GameManager.Instance.CurrentPlayers)
            {
                var playerObj = PrefabUtility.InstantiatePrefab(playerPrefab) as GameObject;
                playerObj.name = player.playerName;
                var playerData = playerObj.GetComponent<PlayerDataManager>();
                var playerRender = playerObj.GetComponent<SpriteRenderer>();
                playerRender.color = colors[player.playerColor];
                playerData.playerData = player;
                playerData.playerId = player.playerId;

                if (spawnIndex >= map.spawnPoints.Length)
                {
                    spawnIndex = 0;
                }

                var pos = map.spawnPoints[spawnIndex++];
                playerObj.transform.position = new Vector3(pos.x, pos.y);
                players.Add(playerObj);
            }
            
            //碰撞
            var colliders = new List<BoxCollider2D>();
            foreach (var groundPrefab in map.groundColliderPrefabs)
            {
                var ground = PrefabUtility.InstantiatePrefab(groundPrefab) as GameObject;
                colliders.AddRange(ground.GetComponentsInChildren<BoxCollider2D>());
            }
            players.ForEach(p =>p.GetComponent<PlayerInteration>().ground = colliders.ToArray());
            
            
            //背景
            var bg = PrefabUtility.InstantiatePrefab(map.backgroundPrefab) as GameObject;
            bg.transform.position = bg.transform.position + new Vector3(0, 0, 10);
            _autoCamera.background = bg.GetComponent<SpriteRenderer>();
            _autoCamera.ResetBackground();
            

        }
    }
}