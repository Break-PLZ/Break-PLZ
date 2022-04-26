using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gamemanager;
    GameObject SaveList;
    public Button prev;
    public GameObject prefab;
    string saveroute;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        prev.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoStartMenu);
        SaveList = GameObject.Find("MenuSection");
        saveroute = string.Format("{0}/{1}", Application.dataPath, "Save");
        System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(saveroute);
        setSaveList(directoryInfo.GetDirectories().Length);
    }
    void setSaveList(int savelength){
        for(int i=0;i<savelength;i++){
            GameObject newPanel = Instantiate(prefab,SaveList.transform);
            setSaveInfo(newPanel,i);
            newPanel.AddComponent<ConnectSave>();
            newPanel.GetComponent<ConnectSave>().saveNum = i;
            newPanel.AddComponent<Button>();
            newPanel.GetComponent<Button>().onClick.AddListener(newPanel.GetComponent<ConnectSave>().connectSave);
            if(gamemanager.GetComponent<GameManager>().sceneNumber==2){
                newPanel.GetComponent<Button>().onClick.AddListener(this.gameObject.GetComponent<IsOverwrite>().OpenCaution);
            }
            else{
                newPanel.GetComponent<Button>().onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoSetEmployee);
            }
            
        }
    }
    void setSaveInfo(GameObject obj,int i){
        GameInfo gi = gamemanager.GetComponent<GameManager>().LoadJsonFile<GameInfo>(Application.dataPath,"Save/"+i+"/GameInfo");
        string sec_to_hour = gi.time.ToString("HH:mm:ss");
        obj.transform.GetChild(0).GetComponent<Text>().text = gi.name;
        obj.transform.GetChild(1).GetComponent<Text>().text = sec_to_hour;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
