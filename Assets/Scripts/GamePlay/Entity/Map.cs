using System;
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


    }
}