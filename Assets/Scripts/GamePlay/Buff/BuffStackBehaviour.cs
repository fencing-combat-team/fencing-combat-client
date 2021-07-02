using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Buff
{
    public class BuffStackBehaviour : MonoBehaviour
    {
        public GameObject buffInfoPrefab;
        private List<GameObject> buffInfoList = new List<GameObject>();
        private List<Entity.Buff> buffs = new List<Entity.Buff>();

        void Start()
        {
        }
        public int GetCount()
        {
            return buffs.Count;
        }
        public void SetBuffInfo(int playerId, Entity.Buff buff)
        {
            var obj = PrefabUtility.InstantiatePrefab(buffInfoPrefab) as GameObject;
            obj.GetComponent<BuffInfoBehaviour>().SetBuffInfo(buff);
            GameObject parent = GameObject.Find("/PlayUI/MainPanel/PlayerPanel/BuffStack" + playerId);
            obj.transform.SetParent(parent.transform);
            obj.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y + GetCount()* 25);
            obj.name = "BuffInfo" + buff.buffId;
            buffs.Add(buff);
            buffInfoList.Add(obj);
        }

        public void RemoveInfo(int playerId, Entity.Buff buff)
        {
            if (!buffs.Remove(buff))
                return;

            GameObject obj = GameObject.Find("BuffInfo" + buff.buffId);
            buffInfoList.Remove(obj);
            Destroy(obj);

            GameObject parent = GameObject.Find("/PlayUI/MainPanel/PlayerPanel/BuffStack" + playerId);
            for (int i = 0; i < buffInfoList.Count; i++)
            {
                buffInfoList[i].transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y + i * 25);
            }
        }
    }
}
