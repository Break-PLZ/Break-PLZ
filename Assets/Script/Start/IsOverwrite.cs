using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsOverwrite : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cause;
    public Button yesbtn;
    public Button gotoInfo;
    GameObject infoState;
    void Start()
    {
        cause = GameObject.Find("SelectMenu").transform.Find("CauseScreen").gameObject;
        infoState = GameObject.Find("SelectMenu").transform.Find("CreateScreen").gameObject;
        gotoInfo = cause.transform.Find("Panel").transform.Find("Yes").GetComponent<Button>();
        yesbtn = infoState.transform.Find("Panel").transform.Find("Yes").GetComponent<Button>();
        yesbtn.onClick.AddListener(CreateGameInfo);
        yesbtn.onClick.AddListener(this.gameObject.GetComponent<SelectGameManager>().gamemanager.GetComponent<GameManager>().gotoSetEmployee);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateGameInfo(){
        GameInfo info = new GameInfo();
        WorkerList wlist = new WorkerList();
        wlist.WL = new List<Worker>();
        wlist.cost = 500;
        GameManager gm = this.GetComponent<SelectGameManager>().gamemanager.GetComponent<GameManager>();
        info.name = infoState.transform.Find("Panel").transform.Find("newName").GetComponent<InputField>().text;
        info.gameNumber = gm.gameInfo.gameNumber;
        string jsonData1 = gm.ObjectToJson(info); // save info
        string jsonData2 = gm.ObjectToJson(wlist); // employee info
        string dirname = "Save/"+gm.gameInfo.gameNumber.ToString()+"/GameInfo";
        string empDir = "Save/"+gm.gameInfo.gameNumber.ToString()+"/Employees";
        gm.CreatetoJsonFile(Application.dataPath,empDir,jsonData2);
        gm.CreatetoJsonFile(Application.dataPath,dirname,jsonData1);
    }
    public void OpenInfo(){
        infoState.SetActive(true);
    }
    public void OpenCaution(){
        cause.SetActive(true);
    }
}
