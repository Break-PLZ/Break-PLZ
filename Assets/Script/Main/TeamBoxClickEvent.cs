using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeamBoxClickEvent : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Start is called before the first frame update
    public int num=0; // This is for test
    public TeamD team;

    public GameObject canvas;
    GameObject arrangeManager;

    FreeCamera fc;

    private Vector3 mOffset;
    private float mZCoord;

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
        mousePos.z=10;

        Vector3 tmpPos=Camera.main.ScreenToWorldPoint(mousePos);
        // float canvasScale=canvas.transform.localScale.x;

        transform.position=tmpPos;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        fc.Activate();
    }
}