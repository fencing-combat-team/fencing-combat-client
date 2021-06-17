using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelsMessages

{
    private static LevelsMessages instance;

    public static LevelsMessages Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LevelsMessages();
            }
            return instance;
        }
    }

    static LevelMessage TEST1 = new LevelMessage("Test1", "这是第一个测试关卡");
    static LevelMessage TEST2 = new LevelMessage("Test2", "这是第二个测试关卡");
    static LevelMessage TEST3 = new LevelMessage("Test3", "这是第三个测试关卡");

    public List<LevelMessage> LevelsList = new List<LevelMessage> { TEST1,TEST2,TEST3 };
}
