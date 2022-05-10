using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTeam : MonoBehaviour
{
    public DataManager data;
    public GameObject SelectedTeamPrefab, selectedList;

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

        // // 선택 목록에 추가
        data.selectedTeams.Add(selected);
    }

    void Instantiation(){
        selectedList = GameObject.Find("SelectedContents");

        GameObject o = (GameObject)Instantiate(SelectedTeamPrefab, selectedList.transform);
        o.transform.GetChild(1).GetComponent<Text>().text = selected.name;
        o.transform.GetChild(2).GetComponent<Text>().text = selected.type;
        o.GetComponent<TeamInfo>().teamInfo = selected;

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
