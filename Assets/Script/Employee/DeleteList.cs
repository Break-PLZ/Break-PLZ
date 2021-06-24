using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                manager.temp.cost += manager.temp.WL[i].cost;
                manager.temp.server -= manager.temp.WL[i].server;
                manager.temp.client -= manager.temp.WL[i].client;
                manager.temp.graphic -= manager.temp.WL[i].graphic;
                manager.temp.sound -= manager.temp.WL[i].sound;
                manager.temp.WL.RemoveAt(i);
                Destroy(obj.transform.GetChild(i).gameObject);
            }
        }
        // 
    }
}
