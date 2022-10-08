using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AreaClickEvent : MonoBehaviour, IPointerClickHandler
{
    public int FloorNumber=1;   // Default is 1F
    public bool isAreaFilled=false;
    public Team team;

    const float doubleClickTime=0.5f;
    private static GameObject lastClickedObject=null;

    float lastClickedTime=0f;
    GameObject floorSettingButton;
    GameObject blankImage;
    GameObject notBlankImage;
    GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        blankImage=this.transform.GetChild(0).gameObject;
        notBlankImage=this.transform.GetChild(1).gameObject;
        text=this.transform.GetChild(2).gameObject;

        blankImage.SetActive(true);
        notBlankImage.SetActive(false);
        text.SetActive(false);

        floorSettingButton=GameObject.Find("FloorSettingButton");
    }

    public void OnPointerClick(PointerEventData eventData){
        if(floorSettingButton.GetComponent<FloorSettingButtonEvent>().isFloorSetting){
            float timeSinceLastClick=eventData.clickTime-lastClickedTime;
            bool bSameObjectClicked=lastClickedObject==eventData.pointerCurrentRaycast.gameObject;
            
            if(timeSinceLastClick<doubleClickTime&&bSameObjectClicked){
                if(isAreaFilled){
                    GameObject.FindWithTag("ArrangeManager").GetComponent<ArrangeManager>().AreaRelease(gameObject);
                }
            }

            lastClickedObject=eventData.pointerCurrentRaycast.gameObject;
            lastClickedTime=eventData.clickTime;
        }
    }

    public void arrangeTeam(Team team){
        text.GetComponent<Text>().text=team.name;

        blankImage.SetActive(false);
        notBlankImage.SetActive(true);
        text.SetActive(true);

        isAreaFilled=true;

        this.team=team;
    }
}
