using System.Linq;
using GamePlay.Entity;
using UnityEngine;

namespace GamePlay.Data
{
    [CreateAssetMenu(fileName = "New LevelDefinitionData", menuName = "ScriptableObjects/Level/LevelDefinitionData", order = 0)]
    public class LevelDefinitionData : ScriptableObject
    {
        public Map[] maps;

        public Map GetMapById(string id) => maps?.FirstOrDefault(m => m.mapId == id);
    }
}