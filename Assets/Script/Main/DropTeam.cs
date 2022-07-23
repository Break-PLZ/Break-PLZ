using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropTeam : MonoBehaviour, IDropHandler
{
    GameObject blankImage;
    GameObject notBlankImage;
    GameObject text;

    public DragAndDropContainer container;

    void IDropHandler.OnDrop(PointerEventData eventData){
        if(container.gameObject.GetComponent<TeamStatus>().name!=null){
            Team temp = container.team;
            int bf = this.GetComponent<TeamStatus>().team.teamNumber;
            int af = container.team.teamNumber;
            
            text.GetComponent<Text>().text=temp.name;

            blankImage.SetActive(false);
            notBlankImage.SetActive(true);
            text.SetActive(true);
            this.GetComponent<TeamStatus>().team = container.team;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        blankImage=this.transform.GetChild(0).gameObject;
        notBlankImage=this.transform.GetChild(1).gameObject;
        text=this.transform.GetChild(2).gameObject;

        blankImage.SetActive(true);
        notBlankImage.SetActive(false);
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
