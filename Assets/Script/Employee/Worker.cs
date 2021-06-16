using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worker: MonoBehaviour
{
    public int cost{get;set;} // cost of worker
    public int server{get;set;}
    public int client{get;set;}
    public int graphic{get;set;}
    public int sound{get;set;}
    void Start(){
        
    }
    void Update(){

    }
    // Start is called before the first frame update
    public void SetProperty(){
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
