using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuEvent: MonoBehaviour
{
    private int direction;
    private int backgroundTimer;
    private bool isSettingsOpening;
    private bool isSettingsClosing;
    GameObject panelSetting;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        backgroundTimer = 0;
        isSettingsOpening = false;
        isSettingsClosing = false;
        panelSetting = GameObject.Find("panelSetting");


        Button btnStart = GameObject.Find("btnStart").GetComponent<Button>();
        btnStart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Room");
        });

        Button btnSetting = GameObject.Find("btnSetting").GetComponent<Button>();
        btnSetting.onClick.AddListener(() =>
        {
            isSettingsOpening = true;
        });

        Button btnQuit = GameObject.Find("btnQuit").GetComponent<Button>();
        btnQuit.onClick.AddListener(() =>
        {
            //ÍË³ö²Ù×÷
        });

        var btnCloseSetting = GameObject.Find("btnCloseSetting").GetComponent<Button>();
        btnCloseSetting.enabled = false;
        btnCloseSetting.onClick.AddListener(() =>
        {
            isSettingsClosing = true;
            btnCloseSetting.enabled = false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (isSettingsOpening == true)
            OpenSettings();
        if (isSettingsClosing == true)
            CloseSettings();


        BackGroundShow();

    }

    void OpenSettings()
    {
        Vector3 vectorSetting = new Vector3(panelSetting.transform.position.x, panelSetting.transform.position.y - 0.1f, panelSetting.transform.position.z);
        panelSetting.transform.position = vectorSetting;
        if (panelSetting.transform.position.y <= 0)
        {
            isSettingsOpening = false;
            GameObject.Find("btnCloseSetting").GetComponent<Button>().enabled = true;
        }

    }

    void CloseSettings()
    {
        Vector3 vectorSetting = new Vector3(panelSetting.transform.position.x, panelSetting.transform.position.y + 0.1f, panelSetting.transform.position.z);
        panelSetting.transform.position = vectorSetting;
        if (panelSetting.transform.position.y >= 10)
        {
            isSettingsClosing = false;
        }
    }

    void BackGroundShow()
    {
        Transform transformCloud1 = GameObject.Find("cloud1").transform;
        float y;
        if (transformCloud1.position.y + 0.01f >= 6.3)
            y = -6.3f + 0.01f;
        else
            y = transformCloud1.position.y + 0.01f;
        Vector3 vectorCloud1 = new Vector3(transformCloud1.position.x, y, transformCloud1.position.z);
        GameObject.Find("cloud1").transform.position = vectorCloud1;



        Transform transformCloud2 = GameObject.Find("cloud2").transform;
        if (transformCloud2.position.y + 0.01f >= 6.3)
            y = -6.3f + 0.01f;
        else
            y = transformCloud2.position.y + 0.01f;
        Vector3 vectorCloud2 = new Vector3(transformCloud2.position.x, y, transformCloud2.position.z);
        GameObject.Find("cloud2").transform.position = vectorCloud2;



        Transform transformParachute = GameObject.Find("parachute").transform;
        float x;
        if (transformParachute.position.x + 0.005f * direction >= -3 || transformParachute.position.x + 0.005f * direction <= -6)
        {
            if (backgroundTimer == 1500)
                direction *= -1;
            x = transformParachute.position.x;
        }
        else
            x = transformParachute.position.x + 0.005f * direction;
        Vector3 vectorParachute = new Vector3(x, transformParachute.position.y, transformParachute.position.z);
        GameObject.Find("parachute").transform.position = vectorParachute;



        Transform transformMan = GameObject.Find("man").transform;
        if (transformMan.position.x + 0.005f * direction >= -3 || transformMan.position.x + 0.005f * direction <= -6)
        {
            if (backgroundTimer == 1500)
                direction *= -1;
            x = transformMan.position.x;
        }
        else
            x = transformMan.position.x + 0.005f * direction;
        Vector3 vectorMan = new Vector3(x, transformMan.position.y, transformMan.position.z);
        GameObject.Find("man").transform.position = vectorMan;

        if (backgroundTimer == 1500)
            backgroundTimer = 0;
        else
            backgroundTimer++;
    }
}
