using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using GamePlay.Player;
using UnityEngine;
using Utils;

namespace GamePlay.Camera
{
    public class AutoCamera : MonoBehaviour
    {
        [Autowired]
        private UnityEngine.Camera _camera;

        //�޸���������������Լ�����findObjectsOfType����������������Ŀ���tag
        private List<CameraLocator> objList = new List<CameraLocator>();

        private Rect _boundary;
        public SpriteRenderer background;

        private void Start()
        {
            this.InitComponents();
            if (background != null)
            {
                ResetBackground();
            }
        }


        public void ResetBackground()
        {
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

        public void AddPlayerTag(CameraLocator tag)
        {
            objList.Add(tag);
        }

        public void RemovePlayerTag(CameraLocator tag)
        {
            objList.Remove(tag);
        }

        private float cameraScaleSpeed = 0;
        private Vector3 cameraMoveSpeed = Vector3.zero;

        public float smoothTime = 0.3f;

        public List<Vector2> InspectPositons = new List<Vector2>();

        private List<Vector2> _removingInspectPositions = new List<Vector2>();

        IEnumerator RunAfter(float time, Action action)
        {
            yield return new WaitForSeconds(time);
            action();
        }

        // Update is called once per frame
        void Update()
        {
            if (objList.Count <= 0)
            {
                return;
            }

            //��Ʒxy����
            var objX = objList.Select(o => o.transform.position.x).ToList();
            var objY = objList.Select(o => o.transform.position.y).ToList();

            //��Ļ��߱�
            float aspectRatio = 1.0f * Screen.width / Screen.height;
            if (InspectPositons.Count + _removingInspectPositions.Count > 0)
            {
                var cameraHeight = _camera.orthographicSize * 2;
                var cameraPos = _camera.transform.position;
                var cameraBounds = new Rect()
                {
                    size = new Vector2(
                        cameraHeight * aspectRatio,
                        cameraHeight
                    ),
                    center = new Vector2(
                        cameraPos.x,
                        cameraPos.y
                    )
                };
                var inboundPos = InspectPositons.FindAll(p => cameraBounds.Contains(p));
                _removingInspectPositions.AddRange(inboundPos);
                InspectPositons.RemoveAll(p => cameraBounds.Contains(p));

                StartCoroutine(RunAfter(3,
                    () => { _removingInspectPositions.RemoveAll(p => inboundPos.Contains(p)); }
                ));
                objX.AddRange(InspectPositons.Select(v => v.x));
                objX.AddRange(_removingInspectPositions.Select(v => v.x));
                objY.AddRange(InspectPositons.Select(v => v.y));
                objY.AddRange(_removingInspectPositions.Select(v => v.y));
            }


            //������xy�����ֵ
            float dist = Mathf.Max(objX.Range(), objY.Range());

            float size = dist * 0.22f + 5;
            //����߶�һ��
            float cameraSize = Mathf.Min(size, _boundary.height / 2);
            // _camera.orthographicSize = cameraSize;
            _camera.orthographicSize =
                Mathf.SmoothDamp(_camera.orthographicSize, cameraSize, ref cameraScaleSpeed, smoothTime);


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
            // _camera.transform.position = pos;

            _camera.transform.position =
                Vector3.SmoothDamp(_camera.transform.position, pos, ref cameraMoveSpeed, smoothTime);
        }
    }
}