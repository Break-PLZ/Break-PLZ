using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShowTalents : MonoBehaviour
, IPointerEnterHandler , IPointerExitHandler
{
    // Start is called before the first frame update
    bool inoutcursor;
    GameObject obj,show;
    void Start()
    {
        obj = Resources.Load("Prefabs/talentInfo") as GameObject;
        inoutcursor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inoutcursor){
            // Debug.Log(Input.mousePosition);
            show.transform.position = Input.mousePosition + new Vector3(255,-180);
        }
    }
    public void OnPointerEnter(PointerEventData eventData){
        inoutcursor = true;
        show = Instantiate(obj,GameObject.FindWithTag("Background").transform);
        Transform temp = show.transform.GetChild(0);
        Debug.Log(temp.childCount);
        workerstatus ws = gameObject.GetComponent<workerstatus>();
        for(int i = 0; i < 3; i++){
            temp.GetChild(i).GetComponent<Text>().text = "";
        }
        for(int i = 0; i < ws.worker.talent.Count; i++){
            temp.GetChild(i).GetComponent<Text>().text = ws.worker.talent[i];
        }
      //  Debug.Log("들어감");
    }
    public void OnPointerExit(PointerEventData eventData){
        inoutcursor = false;
        Destroy(show);
       // Debug.Log("나감");
    }
}
