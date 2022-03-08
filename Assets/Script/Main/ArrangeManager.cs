using UnityEngine;

public class ArrangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    TeamD team;
    void Start()
    {
        
    }

    public void AreaClick(GameObject area){
        Debug.Log("AreaClick");
        if(team!=null){
            Debug.Log("selected: "+team.name);
            
            area.transform.GetChild(0).gameObject.SetActive(true);  // NotBlankImage
            area.transform.GetChild(1).gameObject.SetActive(false); // BlankImage
            area.transform.GetChild(2).gameObject.SetActive(true);  // Text 

            area.GetComponent<AreaClickEvent>().isAreaFilled=true;
        }
    }

    public void AreaRelease(GameObject area){
        area.transform.GetChild(0).gameObject.SetActive(false); // NotBlankImage
        area.transform.GetChild(1).gameObject.SetActive(true);  // BlankImage
        area.transform.GetChild(2).gameObject.SetActive(false); // Text

        area.GetComponent<AreaClickEvent>().isAreaFilled=false;
    }

    public void TeamBoxClicked(TeamD team){
        Debug.Log("TeamBoxClicked");
        this.team=team;
    }

    public void TeamBoxUnclicked(){
        Debug.Log("TeamBoxUnclicked");
        team=null;
    }
}
