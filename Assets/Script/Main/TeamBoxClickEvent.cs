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

    private Vector3 mOffset;
    private float mZCoord;

    void OnMouseDown(){
        mZCoord=Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset=gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos(){
        Vector3 mousePoint=Input.mousePosition;

        mousePoint.z=mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

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
        Vector3 mousePos=Input.mousePosition;

        Debug.Log("Ondrag"+mousePos.x+" "+mousePos.y);
        transform.position=GetMouseWorldPos()+mOffset;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        fc.Activate();
    }
}