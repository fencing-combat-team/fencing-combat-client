using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace UI.Room
{
    [CreateAssetMenu(fileName = "New RoomSetting", menuName = "ScriptableObjects/Room/RoomSetting")]
    public class RoomSetting : ScriptableObject, ISerializationCallbackReceiver
    {
        [Tooltip("游戏局数")]
        public int round = 1;

        [Tooltip("玩家生命")]
        public int lives = 3;

        [Tooltip("玩家数")]
        public int playerNumbers = 4;

        [Tooltip("复活时间")]
        public float recoveryTime = 0;

        public event Action<RoomSetting> SettingChange;
        public void OnSettingChange() => SettingChange?.Invoke(this);

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            OnSettingChange();
        }
    }
}