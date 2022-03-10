using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentsManager : MonoBehaviour
{
    public Button gotomain, btn_dungeon, btn_boss, btn_quest, btn_region;
    public Button gotodetail;
    public GameObject detailPanel1, detailPanel2, ContentSettingPanel;
    GameObject gamemanager;
    public TeamList teamList;
    
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        gotomain.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoMain);
        btn_dungeon.onClick.AddListener(DetailPanelVisible);
        btn_boss.onClick.AddListener(DetailPanelVisible);
        btn_quest.onClick.AddListener(DetailPanelVisible);
        btn_region.onClick.AddListener(DetailPanelVisible);

        gotodetail.onClick.AddListener(OpenContentSettingPanel);

        teamList = gamemanager.GetComponent<GameManager>().LoadJsonFile<TeamList>(Application.dataPath, "Script/TeamListTemp1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DetailPanelVisible(){
        if(detailPanel1.activeSelf == false)
            detailPanel1.SetActive(true);
        else if(detailPanel1.activeSelf == true)
            detailPanel1.SetActive(false);
    }

    void OpenContentSettingPanel(){
        ContentSettingPanel.SetActive(true);
    }
}
