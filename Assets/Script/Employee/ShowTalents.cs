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
        
        if(show==null){
            Debug.Log("eheh");
        }
      //  Debug.Log("들어감");
    }
    public void OnPointerExit(PointerEventData eventData){
        inoutcursor = false;
        Destroy(show);
       // Debug.Log("나감");
    }
}
