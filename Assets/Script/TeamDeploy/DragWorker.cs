using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragWorker : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Start is called before the first frame update
    DragAndDropContainer container;
    bool isDragged = false;
    // public static int sibilingIndex;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if(this.gameObject.name.IndexOf("Worker")!=-1){
            container.gameObject.SetActive(true);
            container.gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+this.GetComponent<workerstatus>().worker.img_name);
            container.worker = this.GetComponent<workerstatus>().worker;
            isDragged = true;
        }
        else{
            if(this.gameObject.GetComponent<Image>().overrideSprite !=null){
                container.gameObject.SetActive(true);
                container.gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+this.GetComponent<workerstatus>().worker.img_name);
                container.worker = this.GetComponent<workerstatus>().worker;
                isDragged = true;
            }
            else{
                return;
            }
        }
        Debug.Log(container.worker.teamNumber);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if(isDragged){
            container.transform.position = eventData.position;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if(isDragged){
            if(this.gameObject.name.IndexOf("Worker")!=-1){
                if(container.GetComponent<Image>().overrideSprite == null){
                    Destroy(this.gameObject);
                }
                else{
                    this.GetComponent<workerstatus>().worker = container.worker;
                    this.GetComponent<workerstatus>().showStatus(this.gameObject);
                }
            }
            else{
                this.GetComponent<workerstatus>().worker = container.worker;
                this.gameObject.GetComponent<Image>().overrideSprite = container.GetComponent<Image>().overrideSprite;
            }
            container.GetComponent<Image>().overrideSprite = null;
            container.worker = new Worker();
            container.gameObject.SetActive(false);
            isDragged = false;
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
