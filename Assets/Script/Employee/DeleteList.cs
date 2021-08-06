using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DeleteList : MonoBehaviour
, IPointerClickHandler
{
    // Start is called before the first frame update
    GameObject obj;
    public Managers manager;
    GameManager gameManager;
    void Start()
    {
        obj = this.gameObject;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData){
        for(int i=0;i<obj.transform.childCount;i++){
            if(eventData.pointerCurrentRaycast.gameObject==obj.transform.GetChild(i).gameObject||eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject==obj.transform.GetChild(i).gameObject){
                StartCoroutine(RunPause(i));
                break; 
            }
        }
        // 
    }
    IEnumerator RunPause(int i){
        Worker tmp = manager.temp.WL[i];
        GameObject reconsider = Instantiate(Resources.Load("Prefabs/Pause"),GameObject.FindWithTag("Background").transform) as GameObject;
        reconsider.GetComponent<Reconsideration>().setcontents(tmp.name,"Cost: "+tmp.cost,"Server: " + tmp.server + "\n"
        + "Client: " + tmp.client + "\n" + "Graphic: " + tmp.graphic + "\n"
        + "Sound: " + tmp.sound, "정말 취소하시겠습니까?",tmp.img_name);       
        yield return StartCoroutine(reconsider.GetComponent<Reconsideration>().decision());
        bool result  = reconsider.GetComponent<Reconsideration>().result;
        Destroy(reconsider);
        if (result){
            manager.temp.cost += tmp.cost;
            manager.temp.server -= tmp.server;
            manager.temp.client -= tmp.client;
            manager.temp.graphic -= tmp.graphic;
            manager.temp.sound -= tmp.sound;
            manager.temp.WL.RemoveAt(i);
            Destroy(obj.transform.GetChild(i).gameObject);
        }
    }


}
