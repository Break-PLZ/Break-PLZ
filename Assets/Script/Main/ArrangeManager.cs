using UnityEngine;

public class ArrangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool isAreaClicked=false;
    bool isTeamBoxClicked=false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AreaClick(GameObject area){
        isAreaClicked=true;
        if(isAreaClicked&&isTeamBoxClicked){
            Debug.Log("HI");
            area.transform.GetChild(1).gameObject.SetActive(false);
            area.transform.GetChild(0).gameObject.SetActive(true);

            area.GetComponent<AreaClickEvent>().isAreaFilled=true;

            isAreaClicked=false;
            isTeamBoxClicked=false;
        }
    }

    public void AreaRelease(GameObject area){
        area.transform.GetChild(1).gameObject.SetActive(true);
        area.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void TeamBoxClick(GameObject teamBox){
        isTeamBoxClicked=true;
    }
}
