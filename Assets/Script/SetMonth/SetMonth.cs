using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMonth : MonoBehaviour
{
    public Slider slider;
    public Text cost;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "0개월";
        cost.text = "$0";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (int)slider.value+"개월";
        cost.text = "$"+(int)slider.value*10;
    }
}
