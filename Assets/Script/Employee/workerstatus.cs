using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class workerstatus : MonoBehaviour
{
    // Start is called before the first frame update
    public Worker worker;
    public void SetProperty(Worker tmp){
        worker.server = tmp.server;
        worker.client = tmp.client;
        worker.sound = tmp.sound;
        worker.graphic = tmp.graphic;
        worker.cost = tmp.cost;
        worker.name = tmp.name;
        worker.img_name = tmp.img_name;
        worker.talent = new List<string>();
        for(int i = 0 ; i < tmp.talent.Count; i++){
            worker.talent.Add(tmp.talent[i]);
        }
    }
    public void InitProperty(){
        worker = new Worker();
        worker.server = Random.Range(0,11);
        worker.client = Random.Range(0,11);
        worker.sound = Random.Range(0,11);
        worker.graphic = Random.Range(0,11);
        worker.cost = Random.Range(1,16);
        worker.img_name = "test_"+Random.Range(1,16).ToString("D3");
        name="testbot"+Random.Range(0,101);
    }
    public void setTalents(List<Dictionary<string, object>> talentList){
        worker.talent = new List<string>();
        int num = Random.Range(1,4);
        int k = 0;
        for(int i =0; i < num; i++){
            k = Random.Range(0,talentList.Count);
            worker.talent.Add(talentList[k]["특성이름"].ToString());
        }
    }
    public void showStatus(GameObject obj){
        obj.transform.Find("status").gameObject.GetComponent<Text>().text = "Server: " + worker.server + "\n"
        + "Client: " + worker.client + "\n" + "Graphic: " + worker.graphic + "\n"
        + "Sound: " + worker.sound;
        obj.transform.Find("name").gameObject.GetComponent<Text>().text = worker.name;
        obj.transform.Find("cost").gameObject.GetComponent<Text>().text = "Cost: " + worker.cost;
        obj.transform.Find("Image").gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+worker.img_name);
    }
}
