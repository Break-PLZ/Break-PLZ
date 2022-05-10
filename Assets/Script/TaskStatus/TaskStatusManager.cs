using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TaskStatusManager : MonoBehaviour
{
    public GameObject floor;
    public GameObject team;
    public GameObject content;

    GameObject gamemanager;
    public TeamListS teamInfo;
    public FloorInfo floorInfo;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        teamInfo = gamemanager.GetComponent<GameManager>().LoadJsonFile<TeamListS>(Application.dataPath, "Script/TeamListTemp");

        OrganizeFloor();
        SetUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OrganizeFloor(){
        foreach(var i in teamInfo.teamList){
            Debug.Log(i.floor_number);
            bool isFloor = false;

            // 층 리스트에 팀이 해당하는 층 클래스가 존재할 경우
            foreach(var j in floorInfo.floorList){
                if(i.floor_number == j.floorNum){
                    isFloor = true;
                    j.teamList.Add(i);
                }
            }

            // 존재하지 않을 경우 새로운 층 클래스 생성 후 추가
            if(!isFloor){
                Floor f = new Floor();
                List<Team> tmpList = new List<Team>();
                
                f.floorNum = i.floor_number;
                tmpList.Add(i);
                f.teamList = tmpList;
                floorInfo.floorList.Add(f);
            }
        }

        // 각 층별로 chamber_number 기준으로 정렬
        foreach(var i in floorInfo.floorList){
            i.teamList = i.teamList.OrderBy(x => x.chamber_number).ToList();
        }

        floorInfo.floorList = floorInfo.floorList.OrderBy(x => x.floorNum).ToList();
    }

    void SetUI(){
        
        foreach(var i in floorInfo.floorList){
            if(i.floorNum == -1)    continue;

            GameObject floorObj = (GameObject)Instantiate(floor);
            floorObj.transform.SetParent(content.transform);

            foreach(var j in i.teamList){
                GameObject teamObj = (GameObject)Instantiate(team);
                teamObj.transform.SetParent(floorObj.transform);
                teamObj.transform.GetChild(3).GetComponent<Text>().text = j.name;
                teamObj.transform.GetChild(4).GetComponent<Text>().text = j.task.state;

                switch(j.type){
                    case "Server":
                        teamObj.transform.GetChild(1).GetComponent<Image>().color = new Color(255/255f,202/255f, 58/255f, 1.0f);
                        break;
                    case "Client":
                        teamObj.transform.GetChild(1).GetComponent<Image>().color = new Color(255/255f,89/255f, 94/255f, 1.0f);
                        break;
                    case "Sound":
                        teamObj.transform.GetChild(1).GetComponent<Image>().color = new Color(138/255f,201/255f, 38/255f, 1.0f);
                        break;
                    case "Graphic":
                        teamObj.transform.GetChild(1).GetComponent<Image>().color = new Color(25/255f,130/255f, 196/255f, 1.0f);
                        break;
                }
            }
        }
    }
}
