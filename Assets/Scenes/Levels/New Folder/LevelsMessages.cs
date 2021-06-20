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

    static LevelMessage TEST1 = new LevelMessage("Test1", "���ǵ�һ�����Թؿ�");
    static LevelMessage TEST2 = new LevelMessage("Test2", "���ǵڶ������Թؿ�");
    static LevelMessage TEST3 = new LevelMessage("Test3", "���ǵ��������Թؿ�");

    public List<LevelMessage> LevelsList = new List<LevelMessage> { TEST1,TEST2,TEST3 };
}
