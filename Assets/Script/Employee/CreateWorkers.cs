using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreateWorkers : MonoBehaviour
, IPointerClickHandler
{
    public GameObject WorkerSelect; // work 선텍 오브젝트 (worker 3개 포함하는 오브젝트)
    public GameObject prefabWorker,prefabWorker1;
    public GameObject WorkerList;
    public List<Worker> tmplist;
    List<Dictionary<string, object>> tList; //for talent setting
    public Managers manager;
    

    // Start is called before the first frame update
    void Start()
    {
        // 임의의 세가지 박스 생성
        tList = GameObject.Find("GameManager").GetComponent<GameManager>().talentList;
        for(int i=0;i<3;i++){
            GameObject newPanel = Instantiate(prefabWorker,WorkerSelect.transform);
            WorkerContents(newPanel,i);
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
                StartCoroutine(RunPause(i));
                break;
            }
        } 
    }
    
    public void WorkerContents(GameObject obj,int i){
        obj.AddComponent<ShowTalents>();
        Worker worker = new Worker();
        worker.InitProperty();
        worker.setTalents(tList);
        // worker.TestMethod();
        tmplist.Insert(i,worker);
        obj.transform.Find("status").gameObject.GetComponent<Text>().text = "Server: " + worker.server + "\n"
        + "Client: " + worker.client + "\n" + "Graphic: " + worker.graphic + "\n"
        + "Sound: " + worker.sound;
        obj.transform.Find("name").gameObject.GetComponent<Text>().text = worker.name;
        obj.transform.Find("cost").gameObject.GetComponent<Text>().text = "Cost: " + worker.cost;
        obj.transform.Find("Image").gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+worker.img_name);
        // Debug.Log("Image/"+worker.img_name); 
    }

    public void ReRoll(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
        tmplist.Clear();
        for(int i=0;i<3;i++){
            GameObject newPanel = Instantiate(prefabWorker,WorkerSelect.transform);
            WorkerContents(newPanel,i);
        }
    }

    IEnumerator RunPause(int i){
        Worker tmp = tmplist[i];
        GameObject reconsider = Instantiate(Resources.Load("Prefabs/Pause"),GameObject.FindWithTag("Background").transform) as GameObject;
        reconsider.GetComponent<Reconsideration>().setcontents(tmp.name,"Cost: "+tmp.cost,"Server: " + tmp.server + "\n"
        + "Client: " + tmp.client + "\n" + "Graphic: " + tmp.graphic + "\n"
        + "Sound: " + tmp.sound, "정말 고용하시겠습니까?",tmp.img_name);
        yield return StartCoroutine(reconsider.GetComponent<Reconsideration>().decision());
        bool result  = reconsider.GetComponent<Reconsideration>().result;
        Destroy(reconsider);
        if(result){         
            manager.temp.server += tmp.server;
            manager.temp.client += tmp.client;
            manager.temp.graphic += tmp.graphic;
            manager.temp.sound += tmp.sound;
            manager.temp.cost -= tmp.cost;
            manager.temp.WL.Add(tmp);
            tmplist.Remove(tmp);
            Destroy(WorkerSelect.transform.GetChild(i).gameObject);
            GameObject newPanel1;
            if(SceneManager.GetActiveScene().name=="EmployeeScene"){
                newPanel1 = Instantiate(prefabWorker1,WorkerList.transform);
            }
            else{
                newPanel1 = Instantiate(prefabWorker,WorkerList.transform);
            }
            manager.WorkerContents(newPanel1,manager.temp.WL.Count-1);
            GameObject newPanel = Instantiate(prefabWorker,WorkerSelect.transform);
            newPanel.transform.SetSiblingIndex(i);
            WorkerContents(newPanel,i);
        }
    }

}
