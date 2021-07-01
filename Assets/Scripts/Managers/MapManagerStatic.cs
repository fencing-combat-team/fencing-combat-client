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
    /// <summary>
    /// 用于测试场景的静态地图加载
    /// </summary>
    public class MapManagerStatic : MonoBehaviour
    {
        public GameObject playerPrefab;
        public PlayerColors colors;

        [Autowired("/Main Camera")]
        private AutoCamera _autoCamera;
        private void Start()
        {
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

        [Tooltip("地图")]
        public Map map;

        private void InitMap()
        {

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
            foreach (var ground in map.groundColliderPrefabs)
            {
                SetTagForAllChildren(ground, "Ground");
                colliders.AddRange(ground.GetComponentsInChildren<BoxCollider2D>());
            }
            players.ForEach(p =>p.GetComponent<PlayerInteration>().ground = colliders.ToArray());
            
            
            //背景
            var bg = map.backgroundPrefab;
            bg.transform.position = bg.transform.position + new Vector3(0, 0, 10);
            _autoCamera.background = bg.GetComponent<SpriteRenderer>();
            _autoCamera.ResetBackground();
            

        }
        private void SetTagForAllChildren(GameObject go, string tag)
        {
            go.tag = tag;
            if (!go.transform.hasChanged) return;
            foreach (Transform child in go.transform)
            {
                SetTagForAllChildren(child.gameObject, tag);
            }
        }
    }
}