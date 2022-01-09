using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerManager : Managers
{
    public Button prev;
    
    public GameObject WorkerList;
    public CreateWorkers CW;
    public GameObject prefabWorker;
    GameObject gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        prev.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoMain);
        prev.onClick.AddListener(gamemanager.GetComponent<GameManager>().saveEmployee);
        temp = gamemanager.GetComponent<GameManager>().LoadJsonFile<WorkerList>(Application.dataPath,"Script/EmployeeTemp");
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
            GameObject newPanel = Instantiate(prefabWorker,WorkerList.transform);
            Worker worker = temp.WL[i];
            WorkerContents(newPanel,i);
        }
        // var jsonData = gamemanager.GetComponent<GameManager>().LoadJsonFile(Application.dataPath,"EmployeeTemp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
