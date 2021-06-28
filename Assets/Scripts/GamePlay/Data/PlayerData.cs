using UnityEngine;

namespace GamePlay.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public string playerName;
        public int score;
    }
}