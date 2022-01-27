using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWorker : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Start is called before the first frame update
    public static Vector2 DefaultPos;
    public static Transform DefaultParent;
    public static int sibilingIndex;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
        DefaultParent = this.transform.parent;
        sibilingIndex = this.transform.GetSiblingIndex();
        Debug.Log(sibilingIndex);
        this.transform.SetParent(GameObject.FindWithTag("Background").transform);
        this.GetComponent<ShowTalents>().OnPointerExit(eventData);
        this.GetComponent<ShowTalents>().enabled = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position; 
        this.transform.position = currentPos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        this.transform.position = DefaultPos;
        this.transform.SetParent(DefaultParent);
        this.transform.SetSiblingIndex(sibilingIndex);
        this.GetComponent<ShowTalents>().enabled = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
