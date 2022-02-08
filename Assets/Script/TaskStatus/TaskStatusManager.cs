using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskStatusManager : MonoBehaviour
{
    public GameObject floor;
    public GameObject team;
    public GameObject content;

    GameObject gamemanager;
    FloorInfo floorinfo;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        floorinfo = gamemanager.GetComponent<GameManager>().LoadJsonFile<FloorInfo>(Application.dataPath, "Script/TeamListTemp");

        SetUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetUI(){
        
        for(int i=0;i<floorinfo.FloorList.Count;i++){
            GameObject f = (GameObject)Instantiate(floor);
            f.transform.parent = content.transform;

            for(int j=0;j<floorinfo.FloorList[i].TeamsInFloor.Count;j++){
                string type_ = floorinfo.FloorList[i].TeamsInFloor[j].type;
                string name_ = floorinfo.FloorList[i].TeamsInFloor[j].name;
                string task_ = floorinfo.FloorList[i].TeamsInFloor[j].task;

                GameObject t = (GameObject)Instantiate(team);
                t.transform.parent = f.transform;
                t.transform.GetChild(3).GetComponent<Text>().text = name_;
                t.transform.GetChild(4).GetComponent<Text>().text = task_;

                switch(type_){
                    case "server":
                        t.transform.GetChild(1).GetComponent<Image>().color = new Color(255/255f,202/255f, 58/255f, 1.0f);
                        break;
                    case "client":
                        t.transform.GetChild(1).GetComponent<Image>().color = new Color(255/255f,89/255f, 94/255f, 1.0f);
                        break;
                    case "sound":
                        t.transform.GetChild(1).GetComponent<Image>().color = new Color(138/255f,201/255f, 38/255f, 1.0f);
                        break;
                    case "graphic":
                        t.transform.GetChild(1).GetComponent<Image>().color = new Color(25/255f,130/255f, 196/255f, 1.0f);
                        break;
                }
            }
        }
    }
}
