using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragTeam : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    DragAndDropContainer container;
    Team team;

    bool isDragged = false;

    FreeCamera fc;

    void Start()
    {
        fc=GameObject.Find("Main Camera").GetComponent<FreeCamera>();

        container = GameObject.Find("ArrangementMode").transform.Find("Canvas").transform.Find("TeamBoxContainer").GetComponent<DragAndDropContainer>();
        team = this.GetComponent<TeamStatus>().team;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        fc.Deactivate();
        container.gameObject.SetActive(true);
        if(this.gameObject.name.IndexOf("TeamBox")!=-1){
            container.gameObject.SetActive(true);
            container.team = this.GetComponent<TeamStatus>().team;
            container.transform.GetChild(0).GetComponent<Text>().text = team.name;
            isDragged = true;
        }
        else{
            if(this.gameObject.GetComponent<TeamStatus>().name !=null){
                container.gameObject.SetActive(true);
                container.team = this.GetComponent<TeamStatus>().team;
                container.transform.GetChild(0).GetComponent<Text>().text = team.name;
                isDragged = true;
            }
            else{
                return;
            }
        }
        container.GetComponent<Image>().raycastTarget=false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if(isDragged){
            Vector3 mousePos=Input.mousePosition;
            mousePos.z=10;
            Vector3 tmpPos=Camera.main.ScreenToWorldPoint(mousePos);
            
            container.transform.position = tmpPos;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if(isDragged){
            if(this.gameObject.name.IndexOf("TeamBox")!=-1){
                if(this.gameObject.GetComponent<TeamStatus>().name !=null){
                    Destroy(this.gameObject);
                }
                else{
                    this.GetComponent<TeamStatus>().team = container.team;
                    this.GetComponent<TeamStatus>().showStatus(this.gameObject);
                }
            }
            else{
                this.GetComponent<TeamStatus>().team = container.team;
                container.transform.GetChild(0).GetComponent<Text>().text = team.name;
            }
            container.transform.GetChild(0).GetComponent<Text>().text = null;
            container.team = new Team();
            container.gameObject.SetActive(false);
            container.GetComponent<Image>().raycastTarget=true;
            isDragged = false;

            fc.Activate();
        }
    }
}