using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoubleClickedWorker : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public float DoubleClickinterval = 0.25f;
    private bool isActive = false;
    private double timer = 0.0f;
    private GameObject manager;
    void Start()
    {
        manager = GameObject.Find("TeamDeployManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Image>().overrideSprite != null){
            isActive = true;
        }
        else{
            isActive = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        if(isActive){
            if((Time.time - timer) < DoubleClickinterval){
                int teamNumber = this.GetComponent<workerstatus>().worker.teamNumber;
                for(int i = 0; i<manager.GetComponent<TeamDeployManager>().temp.WL.Count;i++){
                    if(manager.GetComponent<TeamDeployManager>().temp.WL[i].name == this.GetComponent<workerstatus>().worker.name){
                        manager.GetComponent<TeamDeployManager>().SetList(i);
                        break;
                    }
                }
                this.GetComponent<Image>().overrideSprite = null;
                this.GetComponent<workerstatus>().worker = new Worker();
                this.GetComponent<workerstatus>().worker.teamNumber = teamNumber;
            }
            else{
                timer = Time.time;
            }
        }
    }
}
