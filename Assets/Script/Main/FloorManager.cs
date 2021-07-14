using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    public int floor_num = 1;  // Default 1
    GameObject[] obj=new GameObject[100];
    public GameObject[] obj_canvas;

    public GameObject tmp1, tmp2;

    // Start is called before the first frame update
    void Start()
    {
        obj_canvas = new GameObject[100];
        obj_canvas[0] = tmp2;

        floor_num = 3;  // For test
        for(int i = 1; i < floor_num; i++)
        {
            obj[i] = GameObject.Instantiate(tmp1, new Vector3(-0.33f, i * 3 - 2f, 0), Quaternion.identity);
            obj_canvas[i] = GameObject.Instantiate(tmp2, new Vector3(0, 3*i, 0), Quaternion.identity);

            obj_canvas[i].transform.GetChild(0).GetComponent<Text>().text = string.Concat((i+1).ToString(), "F");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
