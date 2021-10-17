using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorSettingButtonEvent : MonoBehaviour
{
    bool isFloorSetting = false;
    GameObject[] obj_canvas;
    int floor_num, now_floor_num;
    public GameObject ArrangementMode_Canvas;

    // Start is called before the first frame update
    void Start()
    {
        ArrangementMode_Canvas.SetActive(false);
        isFloorSetting = false;

        floor_num = GameObject.Find("FloorManager").GetComponent<FloorManager>().floor_num;
        now_floor_num = floor_num;
        obj_canvas = GameObject.Find("FloorManager").GetComponent<FloorManager>().obj_canvas;

        for (int i = 0; i < floor_num; i++)
            obj_canvas[i].transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

        floor_num = GameObject.Find("FloorManager").GetComponent<FloorManager>().floor_num;

        if (now_floor_num != floor_num)
        {
            obj_canvas = GameObject.Find("FloorManager").GetComponent<FloorManager>().obj_canvas;
            now_floor_num = floor_num;
        }

        isFloorSetting = !isFloorSetting;

        if (isFloorSetting)
        {
            for(int i=0;i<floor_num;i++)
                obj_canvas[i].transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            for (int i = 0; i < floor_num; i++)
                obj_canvas[i].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
