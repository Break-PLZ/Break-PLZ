using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeManager : Managers
{
    // Start is called before the first frame update
    public Button next;
    public GameObject prefabWorker;
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
            temp.server = 0;
            temp.client = 0;
            temp.graphic = 0;
            temp.sound = 0;
            temp.cost = 500;
        }
        for(int i=0;i<temp.WL.Count;i++){
            GameObject newPanel = Instantiate(prefabWorker,WorkerList.transform);
            WorkerContents(newPanel,i);
        }
        // var jsonData = gamemanager.GetComponent<GameManager>().LoadJsonFile(Application.dataPath,"EmployeeTemp");
    }
    // Update is called once per frame
    void Update()
    {
    
    }

    
}
