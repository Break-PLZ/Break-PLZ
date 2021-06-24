using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public SetMonth month;
    public SelectWorkers obj;
    
    void Start()
    {
        slider.value = obj.num*month.slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = obj.num*month.slider.value;
    }
}
