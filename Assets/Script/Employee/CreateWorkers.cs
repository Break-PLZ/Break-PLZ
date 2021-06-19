using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateWorkers : MonoBehaviour
, IPointerClickHandler
{
    public GameObject WorkerSelect; // work 선텍 오브젝트 (worker 3개 포함하는 오브젝트)
    public GameObject WorkerList;
    public SelectWorkers SW;
    public SelectWorkers ServerText, ClientText, GraphicText, SoundText;
    public LeftMoneyScript CostText;
    public int ClickedWorkers = 0;
    // Start is called before the first frame update
    void Start()
    {
    
        // 임의의 세가지 박스 생성
        for(int i=0;i<3;i++){
            GameObject newPanel = new GameObject("Panel");
            // workers stat
            newPanel.AddComponent<Worker>();
            newPanel.GetComponent<Worker>().SetProperty();
            newPanel.AddComponent<CanvasRenderer>();
            newPanel.AddComponent<Image>();
            int rand = Random.Range(0,256);
            newPanel.GetComponent<Image>().color = new Color(0,(float)rand/255,(float)rand/255);
            newPanel.transform.SetParent(WorkerSelect.transform,false);
            WorkerContents(newPanel);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData){
        //클릭시 삭제 후 재생성
        for(int i=0;i<3;i++){
            if(eventData.pointerCurrentRaycast.gameObject==WorkerSelect.transform.GetChild(i).gameObject||eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject==WorkerSelect.transform.GetChild(i).gameObject){
                Worker tmp = WorkerSelect.transform.GetChild(i).gameObject.GetComponent<Worker>();
                SW.num++;
                ServerText.num += tmp.server;
                ClientText.num += tmp.client;
                GraphicText.num += tmp.graphic;
                SoundText.num += tmp.sound;
                CostText.money -= tmp.cost;
                WorkerSelect.transform.GetChild(i).gameObject.transform.SetParent(WorkerList.transform,false);
                GameObject newPanel = new GameObject("Panel");
                // workers stat
                newPanel.AddComponent<Worker>();
                newPanel.GetComponent<Worker>().SetProperty();
                newPanel.AddComponent<CanvasRenderer>();
                newPanel.AddComponent<Image>();
                int rand = Random.Range(0,256);
                newPanel.GetComponent<Image>().color = new Color(0,(float)rand/255,(float)rand/255);
                newPanel.transform.SetParent(WorkerSelect.transform,false);
                newPanel.transform.SetSiblingIndex(i);
                ClickedWorkers +=1;
                WorkerContents(newPanel);
                break;
            }
        }
        
        // 
    }

    void WorkerContents(GameObject obj){
        Worker worker= obj.GetComponent<Worker>();
        GameObject infoText = new GameObject("infoText");
        infoText.AddComponent<Text>();
        Text content = infoText.GetComponent<Text>();
        content.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        content.color = Color.red;
        content.text = "Server: " + worker.server + "\n"
        + "Client: " + worker.client + "\n" + "Graphic: " + worker.graphic + "\n"
        + "Sound: " + worker.sound + "\n" + "Cost: " + worker.cost;
        infoText.transform.SetParent(obj.transform,false);
    }

    public void ReRoll(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
        for(int i=0;i<3;i++){
            GameObject newPanel = new GameObject("Panel");
            // workers stat
            newPanel.AddComponent<Worker>();
            newPanel.GetComponent<Worker>().SetProperty();
            newPanel.AddComponent<CanvasRenderer>();
            newPanel.AddComponent<Image>();
            int rand = Random.Range(0,256);
            newPanel.GetComponent<Image>().color = new Color(0,(float)rand/255,(float)rand/255);
            newPanel.transform.SetParent(WorkerSelect.transform,false);
            WorkerContents(newPanel);
        }
    }

}
