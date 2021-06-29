using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;
using Utils;

public class AutoCamera : MonoBehaviour
{
    [Autowired]
    private Camera camera;

    //�޸���������������Լ�����findObjectsOfType����������������Ŀ���tag
    private List<PlayerTag> objList = new List<PlayerTag>();

    private Rect _boundary;
    public SpriteRenderer background;

    private void Start()
    {
        this.InitComponents();
        _boundary = new Rect()
        {
            size = new Vector2(
                background.bounds.size.x * background.transform.localScale.x,
                background.bounds.size.y * background.transform.localScale.y
            ),
            center = new Vector2(
                background.transform.position.x,
                background.transform.position.y
            )
        };
    }

    public void AddPlayerTag(PlayerTag tag)
    {
        objList.Add(tag);
    }

    public void RemovePlayerTag(PlayerTag tag)
    {
        objList.Remove(tag);
    }


    // Update is called once per frame
    void Update()
    {
        //��Ʒxy����
        var objX = objList.Select(o => o.transform.position.x).ToArray();
        var objY = objList.Select(o => o.transform.position.y).ToArray();
        //������xy�����ֵ
        float dist = Mathf.Max(objX.Range(), objY.Range());

        float size = dist * 0.18f + 5;
        //����߶�һ��
        float cameraSize = Mathf.Min(size, _boundary.height / 2);
        camera.orthographicSize = cameraSize;

        //��Ļ��߱�
        float aspectRatio = 1.0f * Screen.width / Screen.height;
        float cameraXMin = _boundary.xMin + cameraSize * aspectRatio;
        float cameraXMax = _boundary.xMax - cameraSize * aspectRatio;
        float cameraYMin = _boundary.yMin + cameraSize;
        float cameraYMax = _boundary.yMax - cameraSize;

        // ��������ƽ������ֵ
        float avgX = objX.Average();
        float avgY = objY.Average();
        //�������Ϊ����ƽ��ֵ�������ڷ�Χ�ڣ�

        float cameraX = Mathf.Clamp(avgX, cameraXMin, cameraXMax);
        float cameraY = Mathf.Clamp(avgY, cameraYMin, cameraYMax);

        Vector3 pos = new Vector3(cameraX, cameraY, -10);
        camera.transform.position = pos;

      
    }
}