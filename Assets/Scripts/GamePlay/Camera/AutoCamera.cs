using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamera : MonoBehaviour
{
    public Camera camera;

    //�޸���������������Լ�����findObjectsOfType����������������Ŀ���tag
    private PlayerTag[] objList;


    // Update is called once per frame
    void Update()
    {

        objList = Object.FindObjectsOfType<PlayerTag>();


        float x, xall, y, yall, l, w;


        // ��������ƽ������ֵ
        xall = 0; yall = 0;
        for (int i = 0; i < objList.Length; i++)
        {
            xall += objList[i].transform.position.x;
            yall += objList[i].transform.position.y;
        }
        x = xall / objList.Length;
        y = yall / objList.Length;


        //������xy�����ֵ
        float xmin = objList[0].transform.position.x, xmax = objList[0].transform.position.x, ymin = objList[0].transform.position.y, ymax = objList[0].transform.position.x;
        for (int i = 0; i < objList.Length; i++)
        {
            if (objList[i].transform.position.x < xmin) { xmin = objList[i].transform.position.x; } else if (objList[i].transform.position.x > xmax) { xmax = objList[i].transform.position.x; }
            if (objList[i].transform.position.y < ymin) { ymin = objList[i].transform.position.y; } else if (objList[i].transform.position.y > ymax) { ymax = objList[i].transform.position.y; }
        }
        w = xmax - xmin + 10;
        l = ymax - ymin + 10;

        //��xy��ֵ���һ����Ϊ�жϻ�����ֵ
        float test;
        if (w > l) { test = w; } else { test = l; }

        //��������ͷλ���Լ�������С
        camera.transform.position = new Vector3(x, y, -10f);
        camera.orthographicSize = test * 3 / 6.5f;

    }
}
