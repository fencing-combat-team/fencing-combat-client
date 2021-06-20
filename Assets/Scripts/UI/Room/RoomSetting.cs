using UnityEngine;

namespace UI.Room
{
    [CreateAssetMenu(fileName = "���� RoomSetting", menuName = "ScriptableObjects/Room/RoomSetting")]
    public class RoomSetting : ScriptableObject
    {
        [Tooltip("��Ϸ����")]
        public int round = 1;
        [Tooltip("�������")]
        public int lives = 3;    
        [Tooltip("�����")]
        public int playerNumbers = 4;
        [Tooltip("����ʱ��")]
        public float recoveryTime = 0;
    }
}
