using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeamBoxClickEvent : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public TeamD team;

    DragAndDropContainer container;
    bool isDragged = false;

    FreeCamera fc;

    void Start()
    {
        fc=GameObject.Find("Main Camera").GetComponent<FreeCamera>();

        container = GameObject.Find("ArrangementMode").transform.Find("Canvas").transform.Find("TeamBoxContainer").GetComponent<DragAndDropContainer>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        fc.Deactivate();
        container.gameObject.SetActive(true);
        // if(this.gameObject.name.IndexOf("Worker")!=-1){
        //     container.gameObject.SetActive(true);
        //     container.gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+this.GetComponent<workerstatus>().worker.img_name);
        //     container.worker = this.GetComponent<workerstatus>().worker;
        //     isDragged = true;
        // }
        // else{
        //     if(this.gameObject.GetComponent<Image>().overrideSprite !=null){
        //         container.gameObject.SetActive(true);
        //         container.gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+this.GetComponent<workerstatus>().worker.img_name);
        //         container.worker = this.GetComponent<workerstatus>().worker;
        //         isDragged = true;
        //     }
        //     else{
        //         return;
        //     }
        // }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if(isDragged){
            Vector3 mousePos=Input.mousePosition;
            mousePos.z=10;
            Vector3 tmpPos=Camera.main.ScreenToWorldPoint(mousePos);
            
            container.transform.localPosition = tmpPos;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        fc.Activate();
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
}