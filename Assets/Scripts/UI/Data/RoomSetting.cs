using System;
using UnityEngine;

namespace UI.Data
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


        private void Awake()
        {
            DontDestroyOnLoad(this);
            round = PlayerPrefs.GetInt("round", round);
            lives = PlayerPrefs.GetInt("lives", lives);
            playerNumbers = PlayerPrefs.GetInt("playerNumbers", playerNumbers);
            recoveryTime = PlayerPrefs.GetFloat("recoveryTime", recoveryTime);
        }

        public void OnDisable()
        {
            PlayerPrefs.SetInt("round", round);
            PlayerPrefs.SetInt("lives", lives);
            PlayerPrefs.SetInt("playerNumbers", playerNumbers);
            PlayerPrefs.SetFloat("recoveryTime", recoveryTime);
            PlayerPrefs.Save();
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            OnSettingChange();
        }
    }
}