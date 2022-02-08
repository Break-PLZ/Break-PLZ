using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropContainer : MonoBehaviour
{
    // Start is called before the first frame update
    public Worker worker;
    void Start()
    {
        worker = new Worker();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
