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
    public Image image;

    // Start is called before the first frame update
    public void SetProperty(Worker worker){
        server = worker.server;
        client = worker.client;
        sound = worker.sound;
        graphic = worker.graphic;
        cost = worker.cost;
    }
    public void InitProperty(){
        server = Random.Range(0,11);
        client = Random.Range(0,11);
        sound = Random.Range(0,11);
        graphic = Random.Range(0,11);
        cost = Random.Range(0,11);
    }
    public void TestMethod(){
        Debug.Log("hihi "+server+" "+client+" "+graphic+" "+sound+" "+cost);
    }
}
