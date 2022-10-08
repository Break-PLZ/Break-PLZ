using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropTeam : MonoBehaviour, IDropHandler
{
    public DragAndDropContainer container;

    void IDropHandler.OnDrop(PointerEventData eventData){
        if(container.gameObject.GetComponent<DragAndDropContainer>().team.name!=null){
            Team temp = container.team;
            int bf = this.GetComponent<TeamStatus>().team.teamNumber;
            int af = container.team.teamNumber;
            
            this.GetComponent<TeamStatus>().team = container.team;
            this.GetComponent<AreaClickEvent>().arrangeTeam(container.team);
        }
    }
}
