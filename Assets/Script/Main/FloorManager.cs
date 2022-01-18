using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    public int floor_num = 1;  // Default 1
    GameObject[] obj=new GameObject[100];
    GameObject[,] floor_data = new GameObject[100,4];
    public GameObject[] obj_canvas;

    public GameObject tmp1, tmp2;

    GameObject gamemanager;
    FloorInfo floorinfo;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        floorinfo = gamemanager.GetComponent<GameManager>().LoadJsonFile<FloorInfo>(Application.dataPath, "Script/TeamListTemp");
        
        obj_canvas = new GameObject[100];
        obj_canvas[0] = tmp2;

        floor_num = floorinfo.FloorList.Count;  // For test
        for(int i = 1; i < floor_num; i++)
        {
            obj[i] = GameObject.Instantiate(tmp1, new Vector3(-0.33f, i * 3 - 2f, 0), Quaternion.identity);
            obj_canvas[i] = GameObject.Instantiate(tmp2, new Vector3(0, 3*i, 0), Quaternion.identity);

            obj_canvas[i].transform.GetChild(0).GetComponent<Text>().text = string.Concat((i+1).ToString(), "F");

            for(int j=0;j<4;j++)
                obj_canvas[i].transform.GetChild(1).GetChild(j).GetComponent<AreaClickEvent>().FloorNumber=i+1;

        }

        for(int i=0;i<floorinfo.FloorList.Count;i++){
            Floor tmpFloor=floorinfo.FloorList[i];

            if(tmpFloor.FloorNum==0){
                SetNotArrangedTeamList(tmpFloor);
                continue;
            }

            for(int j=0;j<tmpFloor.TeamsInFloor.Count;j++){
                obj_canvas[tmpFloor.FloorNum-1].transform.GetChild(1).GetChild(tmpFloor.TeamsInFloor[j].chamber_number-1).GetChild(0).gameObject.SetActive(true);
                obj_canvas[tmpFloor.FloorNum-1].transform.GetChild(1).GetChild(tmpFloor.TeamsInFloor[j].chamber_number-1).GetChild(2).GetComponent<Text>().text=tmpFloor.TeamsInFloor[j].name;
            }
        }
    }

    void SetNotArrangedTeamList(Floor f){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
