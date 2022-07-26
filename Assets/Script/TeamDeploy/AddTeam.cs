using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTeam : MonoBehaviour
{
    // Start is called before the first frame update
    TeamD newTeam;
    TeamDeployManager tm;
    GameManager gm;
    public InputField teamName;
    public Dropdown teamType;
    void Start()
    {
        tm = GameObject.Find("TeamDeployManager").GetComponent<TeamDeployManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        newTeam = new TeamD();
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void initTeam(){
        newTeam.InitProperty();
        teamName.text = "";
        teamType.value = 0;
    }
    public void saveNewTeam(){
        newTeam.type = teamType.options[teamType.value].text;
        newTeam.name = teamName.text;
        int max = 0;
        for(int i=0; i < tm.teamList.teamList.Count; i++){
            if(max < tm.teamList.teamList[i].teamNumber){
                max = tm.teamList.teamList[i].teamNumber;
            }
        }
        newTeam.teamNumber = max + 1;
        tm.teamList.teamList.Add(newTeam);
        string jsonData = gm.ObjectToJson(tm.teamList);
        
        gm.CreatetoJsonFile(Application.dataPath,tm.tDir,jsonData);
        tm.teamList = gm.LoadJsonFile<TeamList>(Application.dataPath, tm.tDir);
        tm.AddTeam(newTeam.teamNumber-1);
    }
}
