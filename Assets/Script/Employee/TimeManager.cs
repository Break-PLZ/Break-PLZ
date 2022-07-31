using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance;
    GameManager gameManager;
    public float gameTime;
    bool isPause;
    float inGamePeriod;
    Text times;
    SpriteRenderer backgroundColor;
    // Start is called before the first frame update
    public static TimeManager Instance
    {
        get {
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(TimeManager)) as TimeManager;

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
        
    }
    void Start()
    {
        isPause = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        inGamePeriod = 0.0f;
        gameTime = gameManager.gameInfo.time;
        gameManager.loadGameInfo();
        backgroundColor = GameObject.Find("Background").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name=="MainScene"){
            isPause = false;
            gameTime = gameManager.gameInfo.time;
            if(times == null){
                times = GameObject.Find("Times").GetComponent<Text>();
                Debug.Log("find");
            }
        }
        else{
            isPause = true;
            Debug.Log("pause");
        }
        if(!isPause){
            inGamePeriod += Time.deltaTime;
            gameTime += Time.deltaTime;
            times.text = getTimetext(gameTime);
        }
        if(inGamePeriod > 15.0f){
                inGamePeriod = 0.0f;
                gameManager.gameInfo.time = gameTime;
                gameManager.saveGameInfo();
        }
        
    }
    string getTimetext(float time){
        string timeText = "";
        float hours = (time)/30.0f;
        int days = (int) (hours / 24.0f) ;
        int part = ((int)hours % 24) ;
        if(part > 12){
            timeText = days.ToString()+"일차 오후";
            backgroundChange(1);
        }
        else{
            timeText = days.ToString()+"일차 오전";
            backgroundChange(0);
        }
        
        return timeText;
    }
    void backgroundChange(int index){
        if(index == 1){
            backgroundColor.color = new Color(0.9f,0.2f,0.2f);
        }
        else{
            backgroundColor.color = new Color(0.3f,0.4f,0.9f);
        }
    }
}
