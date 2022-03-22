using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectSave : MonoBehaviour
{
    // Start is called before the first frame update
    public int saveNum = 0;
    GameManager manager ;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void connectSave(){
        manager.saveNumber = saveNum;
    }
}
