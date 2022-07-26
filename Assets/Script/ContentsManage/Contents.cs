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
    public List<Team> teams;
    public int server;
    public int client;
    public int graphic;
    public int sound;
    public int duration;
    public int quality;

    public void init(){
        type = "";
        name = "";
        teams.Clear();
        server = 0;
        client = 0;
        graphic = 0;
        sound = 0;
        duration = 0;
        quality = 0;
    }
}