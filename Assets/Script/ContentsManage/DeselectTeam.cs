using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DeselectTeam : MonoBehaviour
{
    public DataManager data;
    public StatManager statM;
    public GameObject deSelectedTeamPrefab, deselectedList;

    Team deselected = new Team();

    public void select(){
        deselected = GetComponent<TeamInfo>().teamInfo;

        data = GameObject.Find("DataManager").GetComponent<DataManager>();
        deselectedList = GameObject.Find("UndeployedContents");
        
        // 미배치 목록에서 삭제
        foreach(var i in data.selectedTeams){
            if(i.teamNumber == deselected.teamNumber){
                data.selectedTeams.Remove(i);
                break;
            }
        }
        Destroy(gameObject);

        // 선택 목록에 추가 및 정렬
        data.teamList.teamList.Add(deselected);
        data.teamList.teamList = data.teamList.teamList.OrderBy(x => x.teamNumber).ToList();
        data.stat.server -= deselected.stat.server;
        data.stat.client -= deselected.stat.client;
        data.stat.graphic -= deselected.stat.graphic;
        data.stat.sound -= deselected.stat.sound;

        Instantiation();
        statM.ShowStat();
    }

    void Instantiation(){
        // index 알아내기
        int index= 0;
        foreach(var i in data.teamList.teamList){
            if(deselected.teamNumber == i.teamNumber){
                break;
            }
            index++;
        }

        // 생성 후 index에 맞게 위치 변경, 정보 입력
        GameObject o = (GameObject)Instantiate(deSelectedTeamPrefab, deselectedList.transform);
        o.transform.SetSiblingIndex(index);
        o.transform.GetChild(1).GetComponent<Text>().text = deselected.name;
        o.transform.GetChild(2).GetComponent<Text>().text = deselected.type;
        o.GetComponent<TeamInfo>().teamInfo = deselected;
        o.GetComponent<SelectTeam>().data = this.data;
        o.GetComponent<SelectTeam>().statM = this.statM;

        switch(deselected.type){
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
}
