using UnityEngine;
using UnityEngine.UI;

public class ArrangeManager : Managers
{
    // Start is called before the first frame update
    public GameObject teamBoxPrefab;
    GameObject gm;
    GameObject fm;

    Team team;
    public TeamList teamList;
    public string eDir;
    public string tDir;

    void Start()
    {
        fm = GameObject.Find("FloorManager");
        // Read JSON and arrange team
        gm = GameObject.Find("GameManager");
        teamList = gm.GetComponent<GameManager>().LoadJsonFile<TeamList>(Application.dataPath, "Script/TeamListTemp1");
        arrangeTeamfromJSON();

        eDir = "Save/" + gm.GetComponent<GameManager>().gameInfo.gameNumber.ToString() + "/Employees";
        tDir = "Save/" + gm.GetComponent<GameManager>().gameInfo.gameNumber.ToString()+"/TeamList";
        temp = gm.GetComponent<GameManager>().LoadJsonFile<WorkerList>(Application.dataPath,eDir);
    }

    void arrangeTeamfromJSON(){
        for(int i=0; i < teamList.teamList.Count; i++ ){
            int tmpFloorNumber=teamList.teamList[i].floor_number;
            
            if(tmpFloorNumber>0){
                arrangeTeam(teamList.teamList[i]);
            }else{
                addTeamToScrollView(teamList.teamList[i]);
            }
        }
    }

    void arrangeTeam(Team team){
        fm.GetComponent<FloorManager>().arrangeTeam(team);
    }

    void addTeamToScrollView(Team team){
        GameObject tmpTeamBox=GameObject.Instantiate(teamBoxPrefab, teamBoxPrefab.transform.parent, true);
        tmpTeamBox.transform.GetChild(0).GetComponent<Text>().text=team.name;
        tmpTeamBox.GetComponent<TeamStatus>().team=team;
        tmpTeamBox.SetActive(true);
    }

    public void AreaClick(GameObject area){
        Debug.Log("AreaClick");
        if(team!=null){
            Debug.Log("selected: "+team.name);
            
            area.transform.GetChild(0).gameObject.SetActive(false); // BlankImage
            area.transform.GetChild(1).gameObject.SetActive(true);  // NotBlankImage
            area.transform.GetChild(2).gameObject.SetActive(true);  // Text 

            area.GetComponent<AreaClickEvent>().isAreaFilled=true;
        }
    }

    public void AreaRelease(GameObject area){
        area.transform.GetChild(0).gameObject.SetActive(true);  // BlankImage
        area.transform.GetChild(1).gameObject.SetActive(false); // NotBlankImage
        area.transform.GetChild(2).gameObject.SetActive(false); // Text

        area.GetComponent<AreaClickEvent>().isAreaFilled=false;
        addTeamToScrollView(area.GetComponent<TeamStatus>().team);
        // List에 다시 추가
    }

    // public void updateTeamJsonData(){
    //     for(int i=0; i < temp.WL.Count; i++){
    //         for(int j=0; j < WorkerList.transform.childCount; j++){
    //             if(temp.WL[i].name == WorkerList.transform.GetChild(j).GetComponent<workerstatus>().worker.name){
    //                temp.WL[i].teamNumber = 0;
    //                break; 
    //             }
    //             if(j == WorkerList.transform.childCount-1){
    //                 temp.WL[i].teamNumber = 99;
    //             }
    //         }
    //     }
    //     string jsonData = gm.ObjectToJson(temp);
    //     gm.CreatetoJsonFile(Application.dataPath,eDir,jsonData);
    // }

    public void TeamBoxArrange(Team team){

    }

    public void TeamBoxRelease(){

    }
}
