using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TeamList{
    public List<TeamD> teamList;
}
[System.Serializable]
public class TeamD
{
    public string type;
    public string name;
    public int floor_number;
    public int chamber_number;

    public List<Worker> members;

    public void SetProperty(TeamD team){
        name = team.name;
        type = team.type;
        floor_number = team.floor_number;
        chamber_number = team.chamber_number;
        members = team.members;
    }
    public void InitProperty(){
        name = "null";
        type = "null";
        floor_number = -1;
        chamber_number = -1;
        members = new List<Worker>();
    }
}