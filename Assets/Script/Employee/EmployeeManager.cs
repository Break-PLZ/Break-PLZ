using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class EmployeeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button next;
    public WorkerList temp;
    public GameObject WorkerList;
    GameObject gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        next.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoSetMonth);
        temp = gamemanager.GetComponent<GameManager>().LoadJsonFile<WorkerList>(Application.dataPath,"EmployeeTemp");
        if(temp==null){
            temp = new WorkerList();
            temp.WL = new List<Worker>();
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
