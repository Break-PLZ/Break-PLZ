using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrangementMode : MonoBehaviour
{
    bool isFloorSetting=false;
    public Button b;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        isFloorSetting = !isFloorSetting;

        if (b.gameObject.activeSelf == false) b.gameObject.SetActive(true);
        else b.gameObject.SetActive(false);

        GameObject.Find("FloorSettingButton").gameObject.SetActive(false);
    }
}
