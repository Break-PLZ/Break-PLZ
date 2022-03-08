using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AreaClickEvent : MonoBehaviour, IPointerClickHandler
{
    public int FloorNumber=1;   // Default is 1F
    public bool isAreaFilled=false;
    public TeamD team;

    const float doubleClickTime=0.5f;
    private static GameObject lastClickedObject=null;

    float lastClickedTime=0f;
    GameObject floorSettingButton;
    // Start is called before the first frame update
    void Start()
    {
        floorSettingButton=GameObject.Find("FloorSettingButton");
    }

    public void OnPointerClick(PointerEventData eventData){
        if(floorSettingButton.GetComponent<FloorSettingButtonEvent>().isFloorSetting){
            float timeSinceLastClick=eventData.clickTime-lastClickedTime;
            bool bSameObjectClicked=lastClickedObject==eventData.pointerCurrentRaycast.gameObject;
            
            if(timeSinceLastClick<doubleClickTime&&bSameObjectClicked){
                // Double Clicked
                if(isAreaFilled) GameObject.FindWithTag("ArrangeManager").GetComponent<ArrangeManager>().AreaRelease(gameObject);
            }
            else{
                if(!isAreaFilled){
                    GameObject.FindWithTag("ArrangeManager").GetComponent<ArrangeManager>().AreaClick(gameObject);
                }else{
                    // Exchange Logic needed
                }
            }

            lastClickedObject=eventData.pointerCurrentRaycast.gameObject;
            lastClickedTime=eventData.clickTime;
        }
    }

    public void arrangeTeam(TeamD team){
        gameObject.transform.Find("BlankImage").gameObject.SetActive(false);
        gameObject.transform.Find("NotBlankImage").gameObject.SetActive(true);
        gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text=team.name;

        isAreaFilled=true;
        this.team=team;
    }
}
