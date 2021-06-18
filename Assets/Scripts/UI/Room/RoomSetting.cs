using UnityEngine;

namespace UI.Room
{
    [CreateAssetMenu(fileName = "创建 RoomSetting", menuName = "ScriptableObjects/Room/RoomSetting")]
    public class RoomSetting : ScriptableObject
    {
        [Tooltip("游戏局数")]
        public int round = 1;
        [Tooltip("玩家生命")]
        public int lives = 3;    
        [Tooltip("玩家数")]
        public int playerNumbers = 4;
        [Tooltip("复活时间")]
        public float recoveryTime = 0;
    }
}
