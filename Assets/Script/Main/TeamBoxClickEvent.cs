using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeamBoxClickEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public int num=0; // This is for test
    public TeamD team;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TeamBoxClickedEvent);   
    }
    
    void TeamBoxClickedEvent(){
        Debug.Log(team.name+" "+team.teamNumber);
    }
}
