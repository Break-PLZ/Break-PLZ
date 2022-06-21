using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectWorkers : MonoBehaviour
{
    public Text text;
    public Text title;
    public Slider slider;
    GameObject obj;
    public Managers managers;
    public int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        obj = text.gameObject;
        UpdateText();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        setfulfillcolor(slider.value);
    }
    void UpdateText(){
        if(obj.name.Contains("Server")){
            num = managers.temp.server;
        }
        else if(obj.name.Contains("Client")){
            num = managers.temp.client;
        }
        else if(obj.name.Contains("Graphic")){
            num = managers.temp.graphic;
        }
        else if(obj.name.Contains("Sound")){
            num = managers.temp.sound;
        }
        else if(obj.name.Contains("LText")){
            num = managers.temp.cost;
        }
        else if(obj.name.Contains("SelectedP")){
            num = managers.temp.WL.Count;
        }
        if(obj.name.Contains("LText")){
            text.text = "$"+num;
        }
        else{
            text.text = ""+num;
        }
    }
    void setfulfillcolor(double value){
        if(value < 400.0f){
            title.color = Color.white;
        }
        else{
            title.color = Color.red;
        }
    }
}
