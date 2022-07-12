using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    GameObject gameManager;
    
    public TeamListS teamList;
    public List<Team> selectedTeams;
    public Stat stat;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        teamList = gameManager.GetComponent<GameManager>().LoadJsonFile<TeamListS>(Application.dataPath, "Script/TeamListTemp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
