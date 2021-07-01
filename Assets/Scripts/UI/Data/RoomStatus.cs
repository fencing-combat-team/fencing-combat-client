using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI.Data
{
    [CreateAssetMenu(fileName = "New Roomstatu", menuName = "ScriptableObjects/Room/RoomStatus")]
    public class RoomStatus : ScriptableObject
    {
        public bool isGaming = false;
        public int GroundsRemained = 0;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Reset()
        {
            isGaming = false;
            GroundsRemained = 0;
        }
        
    }

}