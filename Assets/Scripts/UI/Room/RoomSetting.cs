using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace UI.Room
{
    [CreateAssetMenu(fileName = "New RoomSetting", menuName = "ScriptableObjects/Room/RoomSetting")]
    public class RoomSetting : ScriptableObject, ISerializationCallbackReceiver
    {
        [Tooltip("��Ϸ����")]
        public int round = 1;

        [Tooltip("�������")]
        public int lives = 3;

        [Tooltip("�����")]
        public int playerNumbers = 4;

        [Tooltip("����ʱ��")]
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