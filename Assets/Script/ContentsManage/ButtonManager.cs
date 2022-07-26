using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private DataManager data;
    [SerializeField]
    private ContentsInfoSaver saver;
    [SerializeField]
    private ContentsManager contentsManager;

    public GameObject detailPanel1, detailPanel2, ContentSettingPanel;
    public Text contentsNameText;


    public void clickNext(){
        // 데이터 저장
        saver.contentsInfo.teams = data.selectedTeams;
        saver.contentsInfo.server = data.stat.server;
        saver.contentsInfo.client = data.stat.client;
        saver.contentsInfo.graphic = data.stat.graphic;
        saver.contentsInfo.sound = data.stat.sound;
        saver.contentsInfo.duration = data.duration;

        contentsManager.chking = true;
        contentsManager.buttonInteration();
        // 화면 전환 및 데이터 출력
        ContentSettingPanel.SetActive(false);
        detailPanel1.SetActive(false);
        detailPanel2.SetActive(true);

        contentsManager.ShowContentsDetail();
    }

    public void clickBack(){
        ContentSettingPanel.SetActive(false);
        detailPanel2.SetActive(false);
        detailPanel1.SetActive(true);
    }

    public void clickDetailSetting(){
        ContentSettingPanel.SetActive(true);
        detailPanel1.SetActive(false);
        detailPanel2.SetActive(false);
    }

    public void clickConfirm(){
        if(contentsNameText.text == ""){
            Debug.Log("컨텐츠 이름을 입력해주세요.");
        }
        else{
            string contentsName = contentsNameText.text;
            Debug.Log(contentsName);
            // json에 저장
            
            SceneManager.LoadScene("MainScene");
        }
    }

    public void clickCancel(){
        ContentSettingPanel.SetActive(false);
        detailPanel1.SetActive(false);
        detailPanel2.SetActive(false);

        contentsManager.chking = false;
        contentsManager.buttonInteration();

        // 초기화
        GameObject gameManager = GameObject.Find("GameManager");
        data.teamList = gameManager.GetComponent<GameManager>().LoadJsonFile<TeamList>(Application.dataPath, "Script/TeamListTemp");
        saver.contentsInfo.init();
        data.selectedTeams.Clear();
        data.stat.server = 0;
        data.stat.client = 0;
        data.stat.graphic = 0;
        data.stat.sound = 0;
        data.duration = 0;
    }
}
