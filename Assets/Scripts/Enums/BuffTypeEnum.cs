using System;
using GamePlay.Buff;

namespace Enums
{
    [Serializable]
    public enum BuffTypeEnum : int
    {
        HealthBuff = 0,
        SpeedBuff = 1,
        ShieldBuff = 2,
        JumpBuff = 3
    }
}