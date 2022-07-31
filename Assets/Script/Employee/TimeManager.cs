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
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name=="MainScene"){
            isPause = false;
            gameTime = gameManager.gameInfo.time;
        }
        else{
            isPause = true;
            Debug.Log("pause");
        }
        if(!isPause){
            inGamePeriod += Time.deltaTime;
            gameTime += Time.deltaTime;
            
        }
        if(inGamePeriod > 15.0f){
                inGamePeriod = 0.0f;
                gameManager.gameInfo.time = gameTime;
                gameManager.saveGameInfo();
        }
        
    }
}
