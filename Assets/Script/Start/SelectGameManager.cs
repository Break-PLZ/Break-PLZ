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
        Destroy(GameObject.Find("TimeChecker"));
    }
    void setSaveList(int savelength){
        for(int i=0;i<savelength;i++){
            GameObject newPanel = Instantiate(prefab,SaveList.transform);
            newPanel.AddComponent<ConnectSave>();
            newPanel.GetComponent<ConnectSave>().saveNum = i;
            newPanel.GetComponent<ConnectSave>().connectSave();
            newPanel.AddComponent<Button>();
            newPanel.GetComponent<Button>().onClick.AddListener(newPanel.GetComponent<ConnectSave>().setSaveGM);
            if(gamemanager.GetComponent<GameManager>().sceneNumber==2){
                
                newPanel.GetComponent<Button>().onClick.AddListener(this.gameObject.GetComponent<IsOverwrite>().OpenCaution);
            }
            else{
                newPanel.GetComponent<Button>().onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoSetEmployee);
            }
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
