using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button next;
    GameObject gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        next.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoSetMonth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
