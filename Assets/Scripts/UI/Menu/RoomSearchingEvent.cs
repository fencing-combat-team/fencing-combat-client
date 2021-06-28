using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSearchingEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        // 测试房间
        GameObject go_btnTestRoom =new GameObject("testRoom");
        Button btnTestRoom = go_btnTestRoom.AddComponent<Button>();
        GameObject go_txtTestRoom = new GameObject("Text");
        Text txtTestRoom = go_txtTestRoom.AddComponent<Text>();
        Image imageTestRoom = go_btnTestRoom.AddComponent<Image>();
        imageTestRoom.color = Color.white;
        var content = GameObject.Find("Content");
        btnTestRoom.transform.SetParent(content.transform);
        txtTestRoom.transform.SetParent(go_btnTestRoom.transform);
        txtTestRoom.GetComponent<Text>().text = "测试房间";
        txtTestRoom.fontSize = 25;
        txtTestRoom.font = UnityEngine.Resources.GetBuiltinResource<Font>("Arial.ttf");
        go_btnTestRoom.transform.localPosition = new Vector3(300,-25,0);
        go_btnTestRoom.transform.localScale = new Vector3(1, 1, 1);
        go_txtTestRoom.transform.localPosition = new Vector3(20, 0, 0);
        go_btnTestRoom.GetComponent<RectTransform>().sizeDelta = new Vector2(580, 30);
        go_txtTestRoom.GetComponent<RectTransform>().sizeDelta = new Vector2(580, 30);

        txtTestRoom.color = Color.black;




        var btnEnterRoom = GameObject.Find("btnEnterRoom").GetComponent<Button>();
        btnEnterRoom.enabled = false;
        GameObject.Find("btnEnterRoom").GetComponent<Image>().color = Color.gray;
        btnEnterRoom.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Room");
        });
        btnTestRoom.onClick.AddListener(() =>
        {
            btnEnterRoom.enabled = true;
            GameObject.Find("btnEnterRoom").GetComponent<Image>().color = Color.white;
            imageTestRoom.color = Color.gray;
        });

        var btnBackToMenu = GameObject.Find("btnBackToMenu").GetComponent<Button>();
        btnBackToMenu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
