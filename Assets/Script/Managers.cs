using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Managers : MonoBehaviour
{
    // Start is called before the first frame update
    public WorkerList temp;
    public void WorkerContents(GameObject obj,int i){
        Worker worker = temp.WL[i];
        obj.transform.Find("status").gameObject.GetComponent<Text>().text = "Server: " + worker.server + "\n" 
        + "Client: " + worker.client + "\n" + "Graphic: " + worker.graphic + "\n"
        + "Sound: " + worker.sound;
        obj.transform.Find("name").gameObject.GetComponent<Text>().text = worker.name;
        obj.transform.Find("cost").gameObject.GetComponent<Text>().text = "Cost: " + worker.cost;
        obj.transform.Find("Image").gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+worker.img_name);
        // Debug.Log("Image/"+worker.img_name);
    }
    
}
