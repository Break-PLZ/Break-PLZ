using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamDeployManager : Managers
{
    // Start is called before the first frame update
    GameObject gamemanager;
    public GameObject prefabWorker;
    public GameObject WorkerList;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
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
            WorkerContents(newPanel,i);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
