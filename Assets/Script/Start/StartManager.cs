using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gamemanager;
    public Button playGame,newGame;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        playGame.onClick.AddListener(() => gamemanager.GetComponent<GameManager>().gotoSelectGame(1));
        newGame.onClick.AddListener(() => gamemanager.GetComponent<GameManager>().gotoSelectGame(2));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
