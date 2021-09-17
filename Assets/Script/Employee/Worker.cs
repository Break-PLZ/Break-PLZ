using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Worker
{
    public int cost; // cost of worker
    public int server;
    public int client;
    public int graphic;
    public int sound;
    public string name;
    public string img_name;
    public List<string> talent;

    // Start is called before the first frame update
    public void SetProperty(Worker worker){
        server = worker.server;
        client = worker.client;
        sound = worker.sound;
        graphic = worker.graphic;
        cost = worker.cost;
        name = worker.name;
        img_name = worker.img_name;
        for(int i =0; i<worker.talent.Count; i++){
            talent.Add(worker.talent[i]);
        }
    }
    public void InitProperty(){
        server = Random.Range(0,11);
        client = Random.Range(0,11);
        sound = Random.Range(0,11);
        graphic = Random.Range(0,11);
        cost = Random.Range(1,16);
        img_name = "test_"+Random.Range(1,16).ToString("D3");
        name="testbot"+Random.Range(0,101);
        talent = new List<string>();
        talent.Add("응애");
        talent.Add("응기잇");
        talent.Add("헤으응");
    }

    
    public void TestMethod(){
        Debug.Log("hihi "+img_name);
    }
}
