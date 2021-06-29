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

    static LevelMessage TEST1 = new LevelMessage("GrassMapScene", "����һ�����Թؿ�,����������Ϸ�Ļ�����Ŀ");

    public List<LevelMessage> LevelsList = new List<LevelMessage> { TEST1};
}
