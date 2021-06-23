using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWorkers : MonoBehaviour
{
    public Text text;
    GameObject obj;
    GameManager manager;
    public int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        //initialize
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        obj = text.gameObject;
        if(obj.name.Contains("Server")){
            num = manager.sinfo.server;
        }
        else if(obj.name.Contains("Client")){
            num = manager.sinfo.client;
        }
        else if(obj.name.Contains("Graphic")){
            num = manager.sinfo.graphic;
        }
        else if(obj.name.Contains("Sound")){
            num = manager.sinfo.sound;
        }
        else if(obj.name.Contains("LText")){
            num = manager.sinfo.cost;
        }
        if(obj.name.Contains("LText")){
            text.text = "$"+num;
        }
        else{
            text.text = ""+num;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.name.Contains("Server")){
            num = manager.sinfo.server;
        }
        else if(obj.name.Contains("Client")){
            num = manager.sinfo.client;
        }
        else if(obj.name.Contains("Graphic")){
            num = manager.sinfo.graphic;
        }
        else if(obj.name.Contains("Sound")){
            num = manager.sinfo.sound;
        }
        else if(obj.name.Contains("LText")){
            num = manager.sinfo.cost;
        }
        if(obj.name.Contains("LText")){
            text.text = "$"+num;
        }
        else{
            text.text = ""+num;
        }
    }
}
