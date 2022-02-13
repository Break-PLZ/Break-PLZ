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
    public GameObject ViewportContent;
    public Button floorSettingButton;
    public Button WorkerManagementButton;
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

        // Set Listensers to Buttons
        //floorSettingButton.onClick.AddListener()
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
            int tmpChamberNumber=teamList.teamList[i].chamber_number;
            string tmpTeamName=teamList.teamList[i].name;
            arrangeTeam(tmpFloorNumber, tmpChamberNumber, tmpTeamName);
        }
    }

    void arrangeTeam(int floorNumber, int chamberNumber, string teamName){
            floorList[floorNumber-1].transform.Find("FloorCanvas").GetChild(chamberNumber).Find("NotBlankImage").gameObject.SetActive(true);
            floorList[floorNumber-1].transform.Find("FloorCanvas").GetChild(chamberNumber).Find("BlankImage").gameObject.SetActive(false);
            floorList[floorNumber-1].transform.Find("FloorCanvas").GetChild(chamberNumber).Find("Text").GetComponent<Text>().text=teamName;
    }
}
