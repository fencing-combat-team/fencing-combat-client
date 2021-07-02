using System;
using GamePlay.Buff;

namespace Enums
{
    [Serializable]
    public enum BuffTypeEnum : int
    {
        JumpBuff = 0,
        HealthBuff = 1,
        ShieldBuff = 2,
        SpeedBuff = 3
    }
}