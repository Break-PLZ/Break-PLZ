using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gamemanager;
    GameObject SaveList;
    public Button prev;
    public GameObject prefab;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        prev.onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoStartMenu);
        SaveList = GameObject.Find("MenuSection");
        setSaveList();
    }
    void setSaveList(){
        for(int i=0;i<3;i++){
            GameObject newPanel = Instantiate(prefab,SaveList.transform);
            if(gamemanager.GetComponent<GameManager>().sceneNumber==2){
                newPanel.AddComponent<Button>();
                newPanel.GetComponent<Button>().onClick.AddListener(gamemanager.GetComponent<GameManager>().gotoSetEmployee);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
