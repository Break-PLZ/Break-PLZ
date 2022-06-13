using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectSave : MonoBehaviour
{
    // Start is called before the first frame update
    public int saveNum = 0;
    GameManager manager;
    GameInfo gameInfo;
    void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void connectSave(){
        manager.gameInfo.gameNumber = saveNum;
        setSaveInfo();
    }
    void setSaveInfo(){
        gameInfo = manager.GetComponent<GameManager>().LoadJsonFile<GameInfo>(Application.dataPath,"Save/"+saveNum+"/GameInfo");
        int d = (int)(gameInfo.time * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        this.transform.GetChild(0).GetComponent<Text>().text = gameInfo.name;
        this.transform.GetChild(1).GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void setSaveGM(){
        manager.gameInfo = gameInfo;
    }
}
