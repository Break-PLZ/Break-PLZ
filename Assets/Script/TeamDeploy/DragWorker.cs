using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragWorker : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Start is called before the first frame update
    public static Vector2 DefaultPos;
    public static Transform DefaultParent;
    DragAndDropContainer container;

    
    // public static int sibilingIndex;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        container.gameObject.SetActive(true);
        container.gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+this.GetComponent<workerstatus>().worker.img_name);
        container.worker = this.GetComponent<workerstatus>().worker;
        // DefaultPos = this.transform.position;
        // DefaultParent = this.transform.parent;
        // sibilingIndex = this.transform.GetSiblingIndex();
        // Debug.Log(sibilingIndex);
        // this.transform.SetParent(GameObject.FindWithTag("Background").transform);
        // this.GetComponent<ShowTalents>().OnPointerExit(eventData);
        // this.GetComponent<ShowTalents>().enabled = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        container.transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //container.image.sprite = null;
        this.GetComponent<workerstatus>().worker.teamNumber = container.worker.teamNumber;
        container.gameObject.SetActive(false);
        container.gameObject.GetComponent<Image>().overrideSprite = null;
        container.worker = new Worker();
        this.gameObject.SetActive(false);
        //this.GetComponent<workerstatus>().worker.teamNumber = 
        // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // this.transform.position = DefaultPos;
        // this.transform.SetParent(DefaultParent);
        // this.transform.SetSiblingIndex(sibilingIndex);
        // this.GetComponent<ShowTalents>().enabled = true;
    }
    void Start()
    {
        //workerList = GameObject.Find("WorkerList");
        container = GameObject.Find("TeamDeploy").transform.Find("Container").GetComponent<DragAndDropContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
