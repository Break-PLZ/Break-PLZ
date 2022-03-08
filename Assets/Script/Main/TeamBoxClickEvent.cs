using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeamBoxClickEvent : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    // Start is called before the first frame update
    public int num=0; // This is for test
    public TeamD team;
    GameObject arrangeManager;
    void Start()
    {
        arrangeManager=GameObject.Find("ArrangeManager");
    }

    public void OnSelect (BaseEventData eventData) 
	{
        arrangeManager.GetComponent<ArrangeManager>().TeamBoxClicked(team);
	}

    public void OnDeselect(BaseEventData data)
    {
        arrangeManager.GetComponent<ArrangeManager>().TeamBoxUnclicked();
    }
}