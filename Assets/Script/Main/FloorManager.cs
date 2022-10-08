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
    public Button workerManagementButton;
    public Button teamDeployButton;
    public Button taskButton;

    GameObject gm;
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
        gm = GameObject.Find("GameManager");

        workerManagementButton.onClick.AddListener(gm.GetComponent<GameManager>().gotoWorkerManagement);
        teamDeployButton.onClick.AddListener(gm.GetComponent<GameManager>().gotoTeamDeploy);
        taskButton.onClick.AddListener(gm.GetComponent<GameManager>().gotoTask);
    }

    void setFloorNumber(GameObject floorObj, int number){
        // Setting FloorMarkText
        floorObj.transform.Find("FloorCanvas").Find("FloorMarkText").GetComponent<Text>().text=string.Concat((number).ToString(), "F");

        // Setting number data to AreaClickEvent
        for(int i=0;i<4;i++){
            floorObj.transform.Find("FloorCanvas").GetChild(i).GetComponent<AreaClickEvent>().FloorNumber=number;
        }
    }

    public void arrangeTeam(Team team){
        floorList[team.floor_number-1].transform.Find("FloorCanvas").GetChild(team.chamber_number).GetComponent<AreaClickEvent>().arrangeTeam(team);
    }
}
