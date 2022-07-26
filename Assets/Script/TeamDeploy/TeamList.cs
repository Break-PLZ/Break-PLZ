using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TeamList{
    public List<Team> teamList;
}
[System.Serializable]
public class Task{
    public string state;
    public int progress;
}

[System.Serializable]
public class Stat{
    public int server;
    public int client;
    public int graphic;
    public int sound;
}
[System.Serializable]
public class Team
{
    public string type;
    public int teamNumber;
    public string name;
    public int floor_number;
    public int chamber_number;

    public List<Worker> members;
    public Task task;
    public Stat stat;

    public void SetProperty(Team team){
        teamNumber = team.teamNumber;
        name = team.name;
        type = team.type;
        floor_number = team.floor_number;
        chamber_number = team.chamber_number;
        members = team.members;
    }
    public void InitProperty(){
        teamNumber = 0;
        name = "null";
        type = "null";
        floor_number = -1;
        chamber_number = -1;
        members = new List<Worker>();
    }
}