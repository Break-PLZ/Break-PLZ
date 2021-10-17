using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeamBoxClickEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public int num=0; // This is for test
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text=num.ToString();
    }

    // Update is called once per frame
    
    public void OnButtonClick(){
        GameObject.FindWithTag("ArrangeManager").GetComponent<ArrangeManager>().TeamBoxClick(gameObject);
    }
}
