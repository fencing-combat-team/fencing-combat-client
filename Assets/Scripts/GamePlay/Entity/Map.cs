using System;
using Enums;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Entity
{
    /// <summary>
    /// 地图
    /// </summary>
    [Serializable]
    public class Map
    {
        public string mapId;

        /// <summary>
        /// 地面
        /// </summary>
        public GameObject[] groundColliderPrefabs;

        public GameObject backgroundPrefab;

        public Vector2[] spawnPoints;

        public string title;
        public string description;
        public Sprite shortcut;

        public MapBuff[] buffs;
    }


    [Serializable]
    public class MapBuff
    {
        public BuffTypeEnum buffId;
        public Vector3[] possibleSpawnPoints;
        public float spawnChance;
    }
}