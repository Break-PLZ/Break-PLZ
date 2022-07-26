using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class ContentsManager : MonoBehaviour
{
    public Button gotomain, btn_dungeon, btn_boss, btn_quest, btn_region;
    public Button gotodetail;
    public GameObject detailPanel1, detailPanel2, ContentSettingPanel, undeployedTeamPrefab, undeployedList;
    public Text detail1ExplanationText;

    public Text contentsTypeText, contentsNameText, contentsDurationText, contentsQualityText;

    public bool chking;
    public int previousType = 0;
    
    GameObject gamemanager;

    [SerializeField]
    private DataManager data;
    [SerializeField]
    private StatManager stat;
    [SerializeField]
    private ContentsInfoSaver contentsInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        chking = false;

        gotomain.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoMain);
        btn_dungeon.onClick.AddListener(DetailPanelVisible);
        btn_boss.onClick.AddListener(DetailPanelVisible);
        btn_quest.onClick.AddListener(DetailPanelVisible);
        btn_region.onClick.AddListener(DetailPanelVisible);
        gotodetail.onClick.AddListener(OpenContentSettingPanel);

        ClassifyUndeployedTeam();
        ShowUndeployedTeam();
        stat.ShowStat();
    }

    void DetailPanelVisible(){
        GameObject clickedObj = EventSystem.current.currentSelectedGameObject;
        string contentstype = "";
        int typenum = 0;
        
        switch(clickedObj.name){
            case "DungeonButton":
                contentstype = "던전";
                typenum = 1;
                break;
            case "BossButton":
                contentstype = "보스";
                typenum = 2;
                break;
            case "QuestButton":
                contentstype = "퀘스트";
                typenum = 3;
                break;
            case "RegionButton":
                contentstype = "지역";
                typenum = 4;
                break;
        }

        if(detailPanel1.activeSelf == false || previousType != typenum){
            detailPanel1.SetActive(true);
            detail1ExplanationText.text = "컨텐츠 타입: "+ contentstype;
            contentsInfo.contentsInfo.type = contentstype;
        }
        else if(detailPanel1.activeSelf == true && previousType == typenum)
            detailPanel1.SetActive(false);

        previousType = typenum;
    }

    void OpenContentSettingPanel(){
        ContentSettingPanel.SetActive(true);
    }

    void ClassifyUndeployedTeam(){
        List<Team> tmpList = new List<Team>();
        foreach(var i in data.teamList.teamList){
            if(i.floor_number == -1){
                tmpList.Add(i);
            }
        }

        data.teamList.teamList = tmpList;
    }

    public void ShowUndeployedTeam(){
        data.teamList.teamList = data.teamList.teamList.OrderBy(x => x.teamNumber).ToList();

        foreach(var i in data.teamList.teamList){
            GameObject o = (GameObject)Instantiate(undeployedTeamPrefab, undeployedList.transform);
            o.transform.GetChild(1).GetComponent<Text>().text = i.name;
            o.transform.GetChild(2).GetComponent<Text>().text = i.type;
            o.GetComponent<SelectTeam>().data = this.data;
            o.GetComponent<SelectTeam>().statM = this.stat;
            
            switch(i.type){
                    case "Server":
                        o.transform.GetChild(0).GetComponent<Image>().color = new Color(255/255f,202/255f, 58/255f, 1.0f);
                        break;
                    case "Client":
                        o.transform.GetChild(0).GetComponent<Image>().color = new Color(255/255f,89/255f, 94/255f, 1.0f);
                        break;
                    case "Sound":
                        o.transform.GetChild(0).GetComponent<Image>().color = new Color(138/255f,201/255f, 38/255f, 1.0f);
                        break;
                    case "Graphic":
                        o.transform.GetChild(0).GetComponent<Image>().color = new Color(25/255f,130/255f, 196/255f, 1.0f);
                        break;
            }

            // 데이터 저장
            o.GetComponent<TeamInfo>().teamInfo = i;
        }
    }

    public void ShowContentsDetail(){
        contentsTypeText.text = "컨텐츠 타입: " + contentsInfo.contentsInfo.type;
        contentsDurationText.text = "예상 기간: " + contentsInfo.contentsInfo.duration + "개월";
        contentsQualityText.text = "예상 품질: " + contentsInfo.contentsInfo.quality;
    }

    public void buttonInteration(){
        if(chking){
            btn_dungeon.GetComponent<Button>().interactable = false;
            btn_boss.GetComponent<Button>().interactable = false;
            btn_quest.GetComponent<Button>().interactable = false;
            btn_region.GetComponent<Button>().interactable = false;
        }
        else{
            btn_dungeon.GetComponent<Button>().interactable = true;
            btn_boss.GetComponent<Button>().interactable = true;
            btn_quest.GetComponent<Button>().interactable = true;
            btn_region.GetComponent<Button>().interactable = true;
        }
    }
}
