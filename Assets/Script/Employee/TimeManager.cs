using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance;
    GameManager gameManager;
    public float gameTime;
    float savePeriod;
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
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        savePeriod = 0.0f;
        gameTime = gameManager.gameInfo.time;
    }

    // Update is called once per frame
    void Update()
    {
        savePeriod += Time.deltaTime;
        gameTime += Time.deltaTime;
        if (savePeriod > 15.0f){
            savePeriod = 0.0f;
            gameManager.gameInfo.time = gameTime;
            string jsonData = gameManager.ObjectToJson(gameManager.gameInfo);
            gameManager.CreatetoJsonFile(Application.dataPath,"Save/"+gameManager.gameInfo.gameNumber+"/GameInfo",jsonData);
        }
    }
}
