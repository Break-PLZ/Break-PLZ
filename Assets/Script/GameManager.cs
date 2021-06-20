using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public struct statinfo{
        public int server, client, graphic, sound, cost;
        public statinfo(int server, int client, int graphic, int sound, int cost){
            this.server = server;
            this.client = client;
            this.graphic = graphic;
            this.sound = sound;
            this.cost = cost;
        }
    }
    public statinfo sinfo;
    public static GameManager Instance
    {
        get {
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }// Start is called before the first frame update
    public void gotoSetMonth(){
        SceneManager.LoadScene("SetMonthScene");
    }
    public void gotoSetEmployee(){
        SceneManager.LoadScene("EmployeeScene");
    }
    void Start()
    {
        sinfo = new statinfo(0,0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
