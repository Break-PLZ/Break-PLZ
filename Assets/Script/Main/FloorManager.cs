using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : Managers
{
    public int floorNum = 3;

    // To Do: How to get max floor num?

    List<GameObject> floorList=new List<GameObject>();

    public GameObject floorPrefab;
    public GameObject teamBoxPrefab;
    public Button workerManagementButton;
    public Button teamDeployButton;
    public Button taskButton;
    public Button cashShopButton;

    GameObject gamemanager;
    TeamList teamList;
    // Start is called before the first frame update
    void Start()
    {      
        // Initial Floor Setting from 2nd floor
        floorList.Add(floorPrefab);
        for(int i=2;i<=floorNum;i++){
            GameObject tmpFloor=GameObject.Instantiate(floorPrefab, new Vector3(-0.33f, i * 3 - 5f, 0), Quaternion.identity);
            setFloorNumber(tmpFloor, i);
            floorList.Add(tmpFloor);
        }

        // Read JSON and arrange team
        gamemanager = GameObject.Find("GameManager");
        teamList = gamemanager.GetComponent<GameManager>().LoadJsonFile<TeamList>(Application.dataPath, "Script/TeamListTemp1");
        arrangeTeamfromJSON();

        workerManagementButton.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoWorkerManagement);
        teamDeployButton.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoTeamDeploy);
        taskButton.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoTask);
        cashShopButton.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoCashShop);
    }

    void setFloorNumber(GameObject floorObj, int number){
        // Setting FloorMarkText
        floorObj.transform.Find("FloorCanvas").Find("FloorMarkText").GetComponent<Text>().text=string.Concat((number).ToString(), "F");

        // Setting number data to AreaClickEvent
        for(int i=0;i<4;i++){
            floorObj.transform.Find("FloorCanvas").GetChild(i).GetComponent<AreaClickEvent>().FloorNumber=number;
        }
    }

    void arrangeTeamfromJSON(){
        for(int i=0; i < teamList.teamList.Count; i++ ){
            int tmpFloorNumber=teamList.teamList[i].floor_number;
            
            if(tmpFloorNumber>0){
                arrangeTeam(teamList.teamList[i]);
            }else{
                addTeamToScrollView(teamList.teamList[i]);
            }
        }
    }

    void arrangeTeam(TeamD team){
        floorList[team.floor_number-1].transform.Find("FloorCanvas").GetChild(team.chamber_number).GetComponent<AreaClickEvent>().arrangeTeam(team);
    }

    void addTeamToScrollView(TeamD team){
        GameObject tmpTeamBox=GameObject.Instantiate(teamBoxPrefab, teamBoxPrefab.transform.parent, true);
        tmpTeamBox.transform.GetChild(0).GetComponent<Text>().text=team.name;
        tmpTeamBox.GetComponent<TeamBoxClickEvent>().team=team;
        tmpTeamBox.SetActive(true);
    }
}
