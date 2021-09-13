using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject GameMenu;
    public GameObject Kid;
    public GameObject Cube;
    public GameObject Ground1;
    public GameObject Ground2;
    public Text timeText;
    public Text scoreText;
    public Text connectText;
    private float myTimer;
    private float score;
    private KidManager kidScript;
    // Start is called before the first frame update
    void Start()
    {
        HeadsetManager.HeadsetDisconnected += OnDisconnect;
        HeadsetManager.HeadsetConnected += OnConnect;
        HeadsetManager.UpdatePoorSignalEvent += OnPoorSignal;
        Time.timeScale = 0;
        StartMenu.SetActive(true);
        GameMenu.SetActive(false);
        Kid.SetActive(false);
        Cube.SetActive(false);
        Ground1.SetActive(false);
        Ground2.SetActive(false);
        myTimer = 0F;
        kidScript = Kid.GetComponent<KidManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer();
        scoreFix(kidScript.getScore());
        
    }
    
    public void startButton()
    {
        Time.timeScale = 1;
        StartMenu.SetActive(false);
        GameMenu.SetActive(true);
        Kid.SetActive(true);
        Cube.SetActive(true);
        Ground1.SetActive(true);
        Ground2.SetActive(true);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void timer()
    {
        myTimer += Time.deltaTime;
        float minutes = Mathf.FloorToInt(myTimer / 60);
        float seconds = Mathf.FloorToInt(myTimer % 60);
        timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    public void scoreFix(float score)
    {
        if (!(score > myTimer))
        {
            scoreText.text = "Score:" + score.ToString();
        }
    }

    private void OnDisconnect()
    {
        connectText.text = "Disconnected";
        connectText.color = Color.red;
    }

    private void OnConnect()
    {
        connectText.text = "Connected";
        connectText.color = Color.green;
    }

    private void OnPoorSignal(int value)
    {
        if (value == 0)
        {
            OnConnect();
            return;
        }
        connectText.text = "Weak Signal";
        connectText.color = Color.black;
    }
}
