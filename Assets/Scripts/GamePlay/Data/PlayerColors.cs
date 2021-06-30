using System.Collections.Generic;
using System.Linq;
using Enums;
using GamePlay.Entity;
using UnityEngine;

namespace GamePlay.Data
{
    [CreateAssetMenu(fileName = "New PlayerColors", menuName = "ScriptableObjects/Player/PlayerColors")]
    public class PlayerColors : ScriptableObject
    {
        public PlayerColorPair[] colors;
        
        public Color this[PlayerColorEnum colorEnum]
        {
            get
            {
                return colors.First(c => c.colorEnum == colorEnum).color;
            }
        }
    }
}