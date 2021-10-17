using UnityEngine;
using UnityEngine.EventSystems;

public class AreaClickEvent : MonoBehaviour, IPointerClickHandler
{
    public int FloorNumber=1;   // Default is 1F
    public bool isAreaFilled=false;
    private int AreaNumber;

    const float doubleClickTime=0.5f;
    private static GameObject lastClickedObject=null;
    float lastClickedTime=0f;

    // Start is called before the first frame update
    void Start()
    {
        AreaNumber=gameObject.ToString()[4]-'0';    // Char to Int
    }

    public void OnPointerClick(PointerEventData eventData){
        float timeSinceLastClick=eventData.clickTime-lastClickedTime;
        bool bSameObjectClicked=lastClickedObject==eventData.pointerCurrentRaycast.gameObject;
        
        if(timeSinceLastClick<doubleClickTime&&bSameObjectClicked){
            // Double Clicked
            Debug.Log("Double Clicked");
            GameObject.FindWithTag("ArrangeManager").GetComponent<ArrangeManager>().AreaRelease(gameObject);    
        }
        else{
            GameObject.FindWithTag("ArrangeManager").GetComponent<ArrangeManager>().AreaClick(gameObject);
        }

        lastClickedObject=eventData.pointerCurrentRaycast.gameObject;
        lastClickedTime=eventData.clickTime;
    }
}
