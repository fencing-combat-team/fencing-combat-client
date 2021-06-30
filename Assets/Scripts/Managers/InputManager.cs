using System;
using System.Collections.Generic;
using Core;
using Enums;
using UnityEngine;

namespace Managers
{
    public class InputManager : Singleton<InputManager>
    {
        
        private Dictionary<int, Dictionary<FencingKey, String>> keyMap =
            new Dictionary<int, Dictionary<FencingKey, String>>();
        private Dictionary<int, String> axisMap =
            new Dictionary<int, String>();
        public InputManager()
        {
            axisMap[1] = "Horizontal1";
            keyMap[1] = new Dictionary<FencingKey, string>
            {
                {FencingKey.Attack, "Attack1"},
                {FencingKey.Defend, "Block1"},
                {FencingKey.Jump, "Jump1"},
            };
            
            axisMap[2] = "Horizontal2";
            keyMap[2] = new Dictionary<FencingKey, string>
            {
                {FencingKey.Attack, "Attack2"},
                {FencingKey.Defend, "Block2"},
                {FencingKey.Jump, "Jump2"},
            };
        }

        public bool GetKey(int playerId, FencingKey key)
        {
            if (!keyMap.ContainsKey(playerId)) return false;
            return Input.GetButton(keyMap[playerId][key]);
        }
        
        public bool GetKeyDown(int playerId, FencingKey key)
        {
            if (!keyMap.ContainsKey(playerId)) return false;
            return Input.GetButtonDown(keyMap[playerId][key]);
        }

        public float GetHorizontalAxis(int playerId)
        {
            if (!axisMap.ContainsKey(playerId)) return 0;
            return Input.GetAxis(axisMap[playerId]);
        }
    }
}
