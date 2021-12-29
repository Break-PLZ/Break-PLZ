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
        Dictionary<int, int> talentNumList = new Dictionary<int, int>();
        for(int i=0;i<talentList.Count;i++){
            talentNumList.Add(i,i);
        }
        int num = Random.Range(1,4);
        int k = 0;
        List<int> list;
        for(int i =0; i < num; i++){
            Debug.Log(talentNumList.Keys.Count+":"+i);
            k = Random.Range(0,talentNumList.Keys.Count);
            list = new List<int>(talentNumList.Keys);
            k = list[k];
            talentNumList.Remove(k);
            worker.talent.Add(talentList[k]["특성이름"].ToString());
            if(i==0&&(k==22||k==70)) break;
            if(k==0){
                talentNumList.Remove(42);
            }
            else if(k==2){
                talentNumList.Remove(8);
            }
            else if(k==3){
                talentNumList.Remove(4);
                talentNumList.Remove(9);
                talentNumList.Remove(27);
            }
            else if(k==4||k==9||k==27){
                talentNumList.Remove(3);
            }
            else if(k==8){
                talentNumList.Remove(2);
            }
            else if(k==12){
                talentNumList.Remove(11);
                talentNumList.Remove(13);
            }
            else if(k==11||k==13){
                talentNumList.Remove(12);
            }
            else if(k==14){
                talentNumList.Remove(15);
            }
            else if(k==15){
                talentNumList.Remove(14);
            }
            else if(k==18){
                talentNumList.Remove(26);
                talentNumList.Remove(30);
            }
            else if(k==26||k==30){
                talentNumList.Remove(18);
            }
            else if(k==21){
                talentNumList.Remove(20);
                talentNumList.Remove(32);
            }
            else if(k==20||k==32){
                talentNumList.Remove(21);
            }
            else if(k==23){
                talentNumList.Remove(25);
            }
            else if(k==25){
                talentNumList.Remove(23);
            }
            else if(k==42){
                talentNumList.Remove(0);
            }
            else if(k==45){
                talentNumList.Remove(46);
            }
            else if(k==46){
                talentNumList.Remove(45);
            }
            else{
                Debug.Log("제거안댐");
            }
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
