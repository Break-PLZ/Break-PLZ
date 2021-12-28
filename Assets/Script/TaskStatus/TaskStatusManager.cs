using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                GameObject t = (GameObject)Instantiate(team);
                t.transform.parent = f.transform;
                
            }
        }
    }
}
