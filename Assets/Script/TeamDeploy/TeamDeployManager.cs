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
    public GameObject prefabTeamComposition;
    public GameObject TeamListContent;
    public Button prev;
    TeamList teamList;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        prev.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoMain);
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
            if(temp.WL[i].teamNumber == 0 ){
                SetList(i);
            }  
        }
        teamList = gamemanager.GetComponent<GameManager>().LoadJsonFile<TeamList>(Application.dataPath, "Script/TeamListTemp1");
        SetUI();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void SetUI(){
        for(int i=0; i < teamList.teamList.Count; i++ ){
            GameObject tempObject = Instantiate(prefabTeamComposition,TeamListContent.transform);
            tempObject.transform.Find("TeamNameBlock").Find("NameText").GetComponent<Text>().text = teamList.teamList[i].name;
            GameObject workspaceObject = tempObject.transform.Find("Content").gameObject;
            for(int j=0; j< workspaceObject.transform.childCount; j++){
                workspaceObject.transform.GetChild(j).GetComponent<workerstatus>().worker.teamNumber = teamList.teamList[i].teamNumber;
            }
        }
    }
    public void SetList(int i){
        GameObject newPanel = Instantiate(prefabWorker,WorkerList.transform);
        WorkerContents(newPanel,i);
        newPanel.AddComponent<DragWorker>();
    }
}
