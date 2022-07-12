using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTeam : MonoBehaviour
{
    public DataManager data;
    public StatManager statM;
    public GameObject SelectedTeamPrefab, selectedList;

    [SerializeField]
    int server, client, graphic, sound;

    Team selected = new Team();

    public void select(){
        selected = GetComponent<TeamInfo>().teamInfo;
        
        // 미배치 목록에서 삭제
        foreach(var i in data.teamList.teamList){
            if(i.teamNumber == selected.teamNumber){
                data.teamList.teamList.Remove(i);
                break;
            }
        }
        Destroy(gameObject);

        // 선택 목록에 추가, 팀 능력치 합산
        data.selectedTeams.Add(selected);
        data.stat.server += selected.stat.server;
        data.stat.client += selected.stat.client;
        data.stat.graphic += selected.stat.graphic;
        data.stat.sound += selected.stat.sound;

        Instantiation();
        statM.ShowStat();
    }

    void Instantiation(){
        selectedList = GameObject.Find("SelectedContents");

        GameObject o = (GameObject)Instantiate(SelectedTeamPrefab, selectedList.transform);
        o.transform.GetChild(1).GetComponent<Text>().text = selected.name;
        o.transform.GetChild(2).GetComponent<Text>().text = selected.type;
        o.GetComponent<TeamInfo>().teamInfo = selected;
        o.GetComponent<DeselectTeam>().data = this.data;
        o.GetComponent<DeselectTeam>().statM = this.statM;

        switch(selected.type){
            case "Server":
                o.transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 202 / 255f, 58 / 255f, 1.0f);
                break;
            case "Client":
                o.transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 89 / 255f, 94 / 255f, 1.0f);
                break;
            case "Sound":
                o.transform.GetChild(0).GetComponent<Image>().color = new Color(138 / 255f, 201 / 255f, 38 / 255f, 1.0f);
                break;
            case "Graphic":
                o.transform.GetChild(0).GetComponent<Image>().color = new Color(25 / 255f, 130 / 255f, 196 / 255f, 1.0f);
                break;
        }
    }

    void IncreaseAbility(){

    }
}
