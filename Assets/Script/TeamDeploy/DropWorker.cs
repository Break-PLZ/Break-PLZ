using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropWorker : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    DragAndDropContainer container;
    void IDropHandler.OnDrop(PointerEventData eventData){
        if(container.gameObject.GetComponent<Image>().overrideSprite!=null){
            Worker temp = this.GetComponent<workerstatus>().worker;
            Sprite tempSprite = this.GetComponent<Image>().overrideSprite;
            int bf = this.GetComponent<workerstatus>().worker.teamNumber;
            int af = container.worker.teamNumber;
            
            this.GetComponent<Image>().overrideSprite = container.gameObject.GetComponent<Image>().overrideSprite;
            this.GetComponent<workerstatus>().worker = container.worker;
            
            container.GetComponent<Image>().overrideSprite = tempSprite;
            container.worker = temp;

            this.GetComponent<workerstatus>().worker.teamNumber = bf;
            container.worker.teamNumber = af;
            if(af==0){
                container.worker.teamNumber = bf;
            }
        }
    }
    void Start()
    {
        container = GameObject.Find("TeamDeploy").transform.Find("Container").GetComponent<DragAndDropContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
