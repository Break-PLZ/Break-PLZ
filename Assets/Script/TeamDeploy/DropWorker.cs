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
            this.GetComponent<Image>().overrideSprite = container.gameObject.GetComponent<Image>().overrideSprite;
            container.worker.teamNumber = this.GetComponent<workerstatus>().worker.teamNumber;
            this.GetComponent<workerstatus>().SetProperty(container.worker);
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
