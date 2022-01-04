using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMonthManager : Managers
{
    // Start is called before the first frame update
    GameObject gamemanager;
    public Button prev;
    public Button next;
    
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        prev.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoSetEmployee);
        next.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoMain);
        //next.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoWorkerManagement);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
