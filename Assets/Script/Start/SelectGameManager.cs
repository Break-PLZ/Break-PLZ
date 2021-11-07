using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gamemanager;
    public Button prev;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        prev.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoStartMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
