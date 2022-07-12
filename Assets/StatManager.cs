using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public DataManager data;
    public Text ServerText, ClientText, GraphicText, SoundText, DurationText;
    public Slider ServerSlider, ClientSlider, GraphicSlider, SoundSlider, DurationSlider;

    public void ChangeStat(){

    }

    public void ShowStat(){
        // text 변경
        ServerText.text = data.stat.server.ToString();
        ClientText.text = data.stat.client.ToString();
        GraphicText.text = data.stat.graphic.ToString();
        SoundText.text = data.stat.sound.ToString();

        // slider 변경
        ServerSlider.value = data.stat.server;
        ClientSlider.value = data.stat.client;
        GraphicSlider.value = data.stat.graphic;
        SoundSlider.value = data.stat.sound;
    }

    public void ChangeDuration(){
        int duration = (int)DurationSlider.value;
        DurationText.text = duration.ToString() + "개월";
    }
}
