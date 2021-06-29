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
        public int score1 = 0;
        public int score2 = 0;
        public int score3 = 0;
        public int score4 = 0;

        public void Reset()
        {
            isGaming = false;
            GroundsRemained = 0;
            score1 = 0;
            score2 = 0;
            score3 = 0;
            score4 = 0;
        }
    }

}