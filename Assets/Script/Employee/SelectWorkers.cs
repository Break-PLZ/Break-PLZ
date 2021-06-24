using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectWorkers : MonoBehaviour
{
    public Text text;
    GameObject obj;
    Managers managers;
    public int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        //initialize
        if(SceneManager.GetActiveScene().name=="EmployeeScene"){
            managers = GameObject.Find("EmployeeManager").GetComponent<EmployeeManager>();
        }
        else if(SceneManager.GetActiveScene().name=="SetMonthScene"){
            managers = GameObject.Find("SetMonthManager").GetComponent<SetMonthManager>();
        }
        else if(SceneManager.GetActiveScene().name=="WorkerManagementScene"){
            managers = GameObject.Find("WorkerManager").GetComponent<WorkerManager>();
        }
        
        obj = text.gameObject;
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

    // Update is called once per frame
    void Update()
    {
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
}
