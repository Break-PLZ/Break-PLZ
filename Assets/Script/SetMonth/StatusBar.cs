using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public int stat;
    void Start()
    {
        slider.value = stat;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = stat;
    }
}
