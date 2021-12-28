using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloorInfo{
    public List<Floor> FloorList;
}

[System.Serializable]
public class Floor{
    public int FloorNum;
    public List<Team> TeamsInFloor;
}

[System.Serializable]
public class Team
{
    public string type;
    public string name;
    public bool work;
    public bool waiting;
    public bool error;
    public bool vacation;
    public int progress;
    public string task;
    public int server;
    public int client;
    public int graphic;
    public int sound;
    public int floor_number;
    public int chamber_number;

    public void SetProperty(Team team){
        name = team.name;
        type = team.type;
        floor_number = team.floor_number;
        chamber_number = team.chamber_number;
        work = team.work;
        waiting = team.waiting;
        error = team.error;
        vacation = team.vacation;
        progress = team.progress;
        task = team.task;
        server = team.server;
        client = team.client;
        graphic = team.graphic;
        sound = team.sound;
    }
    public void InitProperty(){
        name = "null";
        type = "null";
        floor_number = -1;
        chamber_number = -1;
        work = false;
        waiting = true;
        error = false;
        work = false;
        progress = 0;
        task = "대기 중";
        server = 0;
        client = 0;
        graphic = 0;
        sound = 0;
    }
}