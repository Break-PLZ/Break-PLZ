using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskStatusManager : MonoBehaviour
{
    public GameObject floor;
    public GameObject team;
    public GameObject content;

    // Start is called before the first frame update
    void Start()
    {
        GameObject floor1 = (GameObject)Instantiate(floor);
        GameObject button1_1 = (GameObject)Instantiate(team);
        GameObject button1_2 = (GameObject)Instantiate(team);
        button1_1.transform.parent = floor1.transform;
        button1_2.transform.parent = floor1.transform;
        floor1.transform.parent = content.transform;

        GameObject floor2 = (GameObject)Instantiate(floor);
        GameObject button2_1 = (GameObject)Instantiate(team);
        GameObject button2_2 = (GameObject)Instantiate(team);
        GameObject button2_3 = (GameObject)Instantiate(team);
        GameObject button2_4 = (GameObject)Instantiate(team);
        button2_1.transform.parent = floor2.transform;
        button2_2.transform.parent = floor2.transform;
        button2_3.transform.parent = floor2.transform;
        button2_4.transform.parent = floor2.transform;
        floor2.transform.parent = content.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
