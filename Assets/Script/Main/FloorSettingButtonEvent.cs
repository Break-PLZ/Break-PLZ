using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorSettingButtonEvent : MonoBehaviour
{
    bool isFloorSetting = false;
    // GameObject[] obj_canvas;
    int floorNum, nowFloorNum;

    GameObject[] buttons;

    public GameObject backButton;
    public GameObject arrangementModeCanvas;
    // // Start is called before the first frame update
    void Start()
    {
        arrangementModeCanvas.SetActive(false);
        isFloorSetting = false;

        floorNum = GameObject.Find("FloorManager").GetComponent<FloorManager>().floorNum;
        nowFloorNum = floorNum;
        
        buttons=GameObject.FindGameObjectsWithTag("Button");
    }

    public void OnClick()
    {
        isFloorSetting = true;
        foreach(GameObject button in buttons){
            button.SetActive(false);
        }

        backButton.SetActive(true);
        arrangementModeCanvas.SetActive(true);
    }

    public void OnClickBackButton(){
        isFloorSetting=false;
        foreach(GameObject button in buttons){
            button.SetActive(true);
        }

        backButton.SetActive(false);
        arrangementModeCanvas.SetActive(false);
    }
}
