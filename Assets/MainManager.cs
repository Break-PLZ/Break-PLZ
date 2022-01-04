using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Button WorkerManagementButton;
    GameObject gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        WorkerManagementButton.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoWorkerManagement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
