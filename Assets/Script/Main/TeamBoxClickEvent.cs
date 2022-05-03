using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeamBoxClickEvent : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Start is called before the first frame update
    public int num=0; // This is for test
    public TeamD team;
    GameObject arrangeManager;
    FreeCamera fc;
    
    void Start()
    {
        arrangeManager=GameObject.Find("ArrangeManager");
        fc=GameObject.Find("Main Camera").GetComponent<FreeCamera>();
    }

    public void OnBeginDrag(PointerEventData eventData){
        fc.Deactivate();
        Debug.Log("Start drag"+transform.position);
    }

    public void OnDrag(PointerEventData eventData){
        Debug.Log("Ondrag"+eventData.position);
        transform.position=eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        fc.Activate();
    }
}