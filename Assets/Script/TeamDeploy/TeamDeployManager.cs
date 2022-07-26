using System;
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
    public TeamList teamList;
    public string eDir;
    public string tDir;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        prev.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoMain);
        eDir = "Save/" + gamemanager.GetComponent<GameManager>().gameInfo.gameNumber.ToString() + "/Employees";
        tDir = "Save/" + gamemanager.GetComponent<GameManager>().gameInfo.gameNumber.ToString()+"/TeamList";
        temp = gamemanager.GetComponent<GameManager>().LoadJsonFile<WorkerList>(Application.dataPath,eDir);
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
        teamList = gamemanager.GetComponent<GameManager>().LoadJsonFile<TeamList>(Application.dataPath, tDir);
        if(teamList != null){
            SetUI();    
        }
        else{
            teamList = new TeamList();
            teamList.teamList = new List<TeamD>();
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SetUI(){
        for(int i=0; i < teamList.teamList.Count; i++ ){
            AddTeam(i);
        }
    }
    public void AddTeam(int i){
        GameObject tempObject = Instantiate(prefabTeamComposition,TeamListContent.transform);
        tempObject.transform.Find("TeamNameBlock").Find("NameText").GetComponent<Text>().text = teamList.teamList[i].name;
        string type= teamList.teamList[i].type;
        switch(type){
            case "Server":
                tempObject.transform.Find("TeamNameBlock").GetComponent<Image>().color = new Color(255/255f,202/255f, 58/255f, 1.0f);
                break;
            case "Client":
                tempObject.transform.Find("TeamNameBlock").GetComponent<Image>().color = new Color(255/255f,89/255f, 94/255f, 1.0f);
                break;
            case "Graphic":
                tempObject.transform.Find("TeamNameBlock").GetComponent<Image>().color = new Color(25/255f,130/255f, 196/255f, 1.0f);
                break;
            case "Sound":
                tempObject.transform.Find("TeamNameBlock").GetComponent<Image>().color = new Color(138/255f,201/255f, 38/255f, 1.0f);
                break;   
        }
        tempObject.transform.Find("TeamMark").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/Team/"+type+"_icon");
        GameObject workspaceObject = tempObject.transform.Find("Content").gameObject;
        for(int j=0; j< workspaceObject.transform.childCount; j++){
            workspaceObject.transform.GetChild(j).GetComponent<workerstatus>().worker.teamNumber = teamList.teamList[i].teamNumber;
        }
        
        for(int j=0; j < teamList.teamList[i].members.Count; j++){
            workspaceObject.transform.GetChild(j).GetComponent<workerstatus>().worker = teamList.teamList[i].members[j];
            workspaceObject.transform.GetChild(j).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+teamList.teamList[i].members[j].img_name);
        }
    }
    
    public void SetList(int i){
        GameObject newPanel = Instantiate(prefabWorker,WorkerList.transform);
        WorkerContents(newPanel,i);
        newPanel.AddComponent<DragWorker>();
    }
    public void getWorkerLeft(){
        GameManager gm = gamemanager.GetComponent<GameManager>();
        for(int i=0; i < temp.WL.Count; i++){
            for(int j=0; j < WorkerList.transform.childCount; j++){
                if(temp.WL[i].name == WorkerList.transform.GetChild(j).GetComponent<workerstatus>().worker.name){
                   temp.WL[i].teamNumber = 0;
                   break; 
                }
                if(j == WorkerList.transform.childCount-1){
                    temp.WL[i].teamNumber = 99;
                }
            }
        }
        string jsonData = gm.ObjectToJson(temp);
        gm.CreatetoJsonFile(Application.dataPath,eDir,jsonData);
    }
    public void findTeam(){
        GameManager gm = gamemanager.GetComponent<GameManager>();
        for(int i = 0; i < TeamListContent.transform.childCount; i++){
            Transform workers = TeamListContent.transform.GetChild(i).transform.Find("Content").transform;
            teamList.teamList[i].members.Clear();
            for(int j=0; j < workers.childCount; j++){
                if(workers.GetChild(j).GetComponent<workerstatus>().worker.name != ""){
                    teamList.teamList[i].members.Add(workers.GetChild(j).GetComponent<workerstatus>().worker);
                } 
            }
        }
        string jsonData = gm.ObjectToJson(teamList);
        gm.CreatetoJsonFile(Application.dataPath,tDir,jsonData);
    }
}
