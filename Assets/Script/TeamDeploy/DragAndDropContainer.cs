using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropContainer : MonoBehaviour
{
    // Start is called before the first frame update
    public Worker worker;
    public Team team;
    void Start()
    {
        worker = new Worker();
        team = new Team();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
