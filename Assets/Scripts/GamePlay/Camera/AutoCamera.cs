using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamera : MonoBehaviour
{
    public Camera camera;

    //�޸���������������Լ�����findObjectsOfType����������������Ŀ���tag
    private PlayerTag[] objList;

    //��ͼ���������ұ߽�
    private float leftBoundary = -24f;
    private float rightBoundary = 24f;
    private float upBoundary = 10f;
    private float downBoundary = -17f;
    private float tmpSizeX;
    private float tmpSizeY;


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
        float xmin = objList[0].transform.position.x, xmax = objList[0].transform.position.x, ymin = objList[0].transform.position.y, ymax = objList[0].transform.position.y;
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

        //��������ͷλ���Լ�������С(ͬʱ�������߽�)
        Vector3 newPos = new Vector3(x, y, -10f);
        float newSize = test * 3 / 6.5f;
        //float newSize2 = newSize;

        /*
        if (newPos.x - newSize * 16 / 9.0f < leftBoundary)
        {
            newPos = new Vector3(camera.transform.position.x, newPos.y, newPos.z);
            newSize = camera.orthographicSize;
        }
        */

        /*
        if (newPos.x - newSize * 16 / 9.0f < leftBoundary)
        {
            if (l * 3 / 6.5f >= tmpSizeY)
            {
                newPos = new Vector3(camera.transform.position.x+ (l * 3 / 6.5f- camera.orthographicSize) * 16 / 9.0f, newPos.y, -10f);
                newSize2 = l * 3 / 6.5f;
                tmpSizeX = newSize2;
            }
            else if(newSize >= tmpSizeX)
            {
                newPos = new Vector3(camera.transform.position.x+(newSize - camera.orthographicSize) * 16 / 9.0f, newPos.y, -10f);
                newSize2 = newSize;
                tmpSizeY = newSize2;
            }
            else
            {
                newPos = new Vector3(camera.transform.position.x, newPos.y, -10f);
                newSize2 = camera.orthographicSize;
                tmpSizeX = newSize2;
                tmpSizeY = newSize2;
            }

        }
        else
        {
            tmpSizeX = camera.orthographicSize;
            tmpSizeY = camera.orthographicSize;
        }

        if (newPos.x + newSize * 16 / 9.0f > rightBoundary)
        {

        }
        if (newPos.y - newSize < downBoundary
            || newPos.y + newSize > upBoundary)
        {
            newPos = new Vector3(newPos.x, camera.transform.position.y, -10f);
            newSize2 = camera.orthographicSize;
        }
        */

        camera.transform.position = newPos;
        camera.orthographicSize = newSize;//newSize2;


    }
}
