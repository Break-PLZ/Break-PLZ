using UnityEngine;

public class ArrangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject selectedTeamBox;
    void Start()
    {
        
    }

    public void AreaClick(GameObject area, GameObject lastClickedObject){
        if(selectedTeamBox!=null){
            Debug.Log("selected: "+selectedTeamBox);
            Debug.Log("lastClicked: "+lastClickedObject);
            if(selectedTeamBox==lastClickedObject){
            area.transform.GetChild(0).gameObject.SetActive(true);  // NotBlankImage
            area.transform.GetChild(1).gameObject.SetActive(false); // BlankImage
            area.transform.GetChild(2).gameObject.SetActive(true);  // Text 

            area.GetComponent<AreaClickEvent>().isAreaFilled=true;
            }
        }
    }

    public void AreaRelease(GameObject area){
        area.transform.GetChild(0).gameObject.SetActive(false); // NotBlankImage
        area.transform.GetChild(1).gameObject.SetActive(true);  // BlankImage
        area.transform.GetChild(2).gameObject.SetActive(false); // Text

        area.GetComponent<AreaClickEvent>().isAreaFilled=false;
    }

    public void TeamBoxClick(GameObject teamBox){
        selectedTeamBox=teamBox;
    }
}
