using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMessage 
{
    #region ����
    public string name;
    public int score = 0;
    //image headphoto  ͷ��ͼƬ

    #endregion

    public PlayerMessage()
    {
        name = "default";
        score = 0;
    }

    public PlayerMessage(string name)
    {
        this.name = name;
        score = 0;
    }
}
