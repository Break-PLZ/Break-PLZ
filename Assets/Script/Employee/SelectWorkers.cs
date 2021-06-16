using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWorkers : MonoBehaviour
{
    public Text text;
    public int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        //initialize
        text.text = ""+num;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ""+num;
    }
}
