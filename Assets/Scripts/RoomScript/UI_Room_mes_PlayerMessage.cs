using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMessage 
{
    #region ����
    public string name;
    public int score;
    //image headphoto  ͷ��ͼƬ

    #endregion

    public PlayerMessage()
    {
        name = "None Player";
        score = 0;
    }

    public PlayerMessage(string name)
    {
        this.name = name;
        score = 0;
    }
}
