using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Floor{
    public int floorNum;
    public List<Team> teamList;
}

[System.Serializable]
public class FloorInfo{
    public List<Floor> floorList;
}