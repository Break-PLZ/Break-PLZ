using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTeam : MonoBehaviour
{
    // Start is called before the first frame update
    TeamD newTeam;
    void Start()
    {
        newTeam = new TeamD();
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void initTeam(){
        newTeam.InitProperty();
        Debug.Log(newTeam.chamber_number);
    }
}
