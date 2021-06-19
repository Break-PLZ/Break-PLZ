using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWorkersBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject btn;
    bool state;
    void Start()
    {
        target.SetActive(false);
        state = false;
        btn.transform.position = new Vector2(768,25);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked(){
        if(state==false){
            target.SetActive(true);
            state = true;
            btn.transform.position = new Vector2(768,250);
        }
        else{
            target.SetActive(false);
            state = false;
            btn.transform.position = new Vector2(768,25);
        }
    }
}
