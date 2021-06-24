using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerManager : Managers
{
    public Button prev;
    
    public GameObject WorkerList;
    GameObject gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        prev.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoSetMonth);
        temp = gamemanager.GetComponent<GameManager>().LoadJsonFile<WorkerList>(Application.dataPath,"EmployeeTemp");
        if(temp==null){
            temp = new WorkerList();
            temp.WL = new List<Worker>();
            temp.server = 0;
            temp.client = 0;
            temp.graphic = 0;
            temp.sound = 0;
            temp.cost = 500;
        }
        for(int i=0;i<temp.WL.Count;i++){
            GameObject newPanel = new GameObject("Panel");
            newPanel.AddComponent<CanvasRenderer>();
            newPanel.AddComponent<Image>();
            Worker worker = temp.WL[i];
            GameObject infoText = new GameObject("infoText");
            infoText.AddComponent<Text>();
            Text content = infoText.GetComponent<Text>();
            content.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            content.color = Color.red;
            content.text = "Server: " + worker.server + "\n"
            + "Client: " + worker.client + "\n" + "Graphic: " + worker.graphic + "\n"
            + "Sound: " + worker.sound + "\n" + "Cost: " + worker.cost;
            infoText.transform.SetParent(newPanel.transform,false);
            newPanel.gameObject.transform.SetParent(WorkerList.transform,false);
        }
        // var jsonData = gamemanager.GetComponent<GameManager>().LoadJsonFile(Application.dataPath,"EmployeeTemp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
