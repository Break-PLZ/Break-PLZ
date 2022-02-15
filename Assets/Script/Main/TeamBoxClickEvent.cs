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
    GameObject arrangeManager;
    void Start()
    {
        arrangeManager=GameObject.Find("ArrangeManager");
        gameObject.GetComponent<Button>().onClick.AddListener(sendTeamBoxClicked);
    }

    void sendTeamBoxClicked(){
        arrangeManager.GetComponent<ArrangeManager>().TeamBoxClick("hi");
    }

}
