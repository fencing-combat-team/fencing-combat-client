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
                var playerObj = Instantiate(playerPrefab);
                playerObj.name = player.playerName;
                var playerData = playerObj.GetComponent<PlayerDataManager>();
                var playerRender = playerObj.GetComponent<SpriteRenderer>();
                playerRender.color = colors[player.playerColor];
                playerData.playerData = player;
                playerData.PlayerId = player.playerId;

                if (spawnIndex >= map.spawnPoints.Length)
                {
                    spawnIndex = 0;
                }

                var pos = map.spawnPoints[spawnIndex++];
                playerObj.transform.position = new Vector3(pos.x, pos.y);
                playerObj.GetComponent<PlayerHealth>().spawnPoint = new Vector3(pos.x, pos.y);
                players.Add(playerObj);
            }
            
            //碰撞
            var colliders = new List<BoxCollider2D>();
            foreach (var groundPrefab in map.groundColliderPrefabs)
            {
                var ground = Instantiate(groundPrefab);
                SetTagForAllChildren(ground, "Ground");
                colliders.AddRange(ground.GetComponentsInChildren<BoxCollider2D>());
            }
            players.ForEach(p =>p.GetComponent<PlayerInteration>().ground = colliders.ToArray());
            
            
            //背景
            var bg = Instantiate(map.backgroundPrefab);
            bg.transform.position = bg.transform.position + new Vector3(0, 0, 10);
            _autoCamera.background = bg.GetComponent<SpriteRenderer>();
            _autoCamera.ResetBackground();
            
            //buff
            var buffManagerObj = new GameObject();
            buffManagerObj.name = "BuffManager";
            var buffManager = buffManagerObj.AddComponent<BuffManager>();
            buffManager.map = map;
            buffManager.buffPrefab = UnityEngine.Resources.Load<GameObject>("Prefabs/Buff/Buff");


            
            //Weapon
            var weaponManagerObj = new GameObject();
            buffManagerObj.name = "WeaponManager";
            var weaponManager = weaponManagerObj.AddComponent<PlayerWeapons>();
            weaponManager.map = map;
            weaponManager.hammerPrefab = UnityEngine.Resources.Load<GameObject>("Prefabs/Weapon/hammer");
            weaponManager.longswordPrefab = UnityEngine.Resources.Load<GameObject>("Prefabs/Weapon/longSword");
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