using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamStatus : MonoBehaviour
{
    public Team team;
    
    public void SetProperty(Team tmp){
        team.SetProperty(tmp);
    }

    public void InitProperty(){
        team.InitProperty();
    }

    public void showStatus(GameObject obj){
        // obj.transform.Find("status").gameObject.GetComponent<Text>().text = "Server: " + worker.server + "\n"
        // + "Client: " + worker.client + "\n" + "Graphic: " + worker.graphic + "\n"
        // + "Sound: " + worker.sound;
        // obj.transform.Find("name").gameObject.GetComponent<Text>().text = worker.name;
        // obj.transform.Find("cost").gameObject.GetComponent<Text>().text = "Cost: " + worker.cost;
        // obj.transform.Find("Image").gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+worker.img_name);
    }
}
