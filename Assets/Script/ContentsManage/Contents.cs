using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ContentsList{
    public List<ContentsD> teamList;
}
[System.Serializable]
public class ContentsD
{
    public string type;
    public string name;
    public List<TeamD> teams;
    public int server_ability;
    public int client_ability;
    public int graphic_ability;
    public int sound_ability;
    public int duration;
    public int quality;

    public void SetProperty(ContentsD content){
        // teamNumber = team.teamNumber;
        // name = team.name;
        // type = team.type;
        // floor_number = team.floor_number;
        // chamber_number = team.chamber_number;
        // members = team.members;
    }
    public void InitProperty(){
        // teamNumber = 0;
        // name = "null";
        // type = "null";
        // floor_number = -1;
        // chamber_number = -1;
        // members = new List<Worker>();
    }
}