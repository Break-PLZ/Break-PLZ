using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        worker.img_name = "worker_"+Random.Range(0,117).ToString("D3");
        worker.name=nameGenerate();
    }

    string nameGenerate(){
        Names names = GameObject.Find("GameManager").GetComponent<GameManager>().LoadJsonFile<Names>(Application.dataPath,"Resources/Data/name");
        string name_generated;
        name_generated = names.Last[Random.Range(0,names.Last.Count)] + names.First_F[Random.Range(0,names.First_F.Count)];
        return name_generated;
    }
    public void setTalents(List<Dictionary<string, object>> talentList){
        worker.talent = new List<string>();
        Dictionary<int, int> talentNumList = new Dictionary<int, int>();
        List<int> allList = new List<int>();
        for(int i=0;i<talentList.Count;i++){
            talentNumList.Add(i,i);
            if(talentList[i]["중복불가"].ToString()=="all") allList.Add(i);
        }
        int num = Random.Range(1,4);
        int k = 0;
        List<int> list;
        for(int i =0; i < num; i++){
            //Debug.Log(talentNumList.Keys.Count+":"+i);
            k = Random.Range(0,talentNumList.Keys.Count);
            list = new List<int>(talentNumList.Keys);
            k = list[k];
            talentNumList.Remove(k);   
            worker.talent.Add(talentList[k]["특성이름"].ToString());
            string target = talentList[k]["중복불가"].ToString();
            if(i==0){
                if(target=="all") break;
                else{
                    for(int j = 0; j<allList.Count;j++){
                        talentNumList.Remove(allList[j]); 
                    }
                }
            }
            if(target!=""){
                // Debug.Log(k+": 중복불가!");
                List<string> duplication =  target.Split(';').ToList();
                for(int j = 0; j < duplication.Count; j++){
                    talentNumList.Remove(int.Parse(duplication[j]));
                }
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
