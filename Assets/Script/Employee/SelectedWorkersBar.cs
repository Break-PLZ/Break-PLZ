using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWorkersBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject btn;
    bool state;
    float x, y;
    void Start()
    {
        target.SetActive(false);
        state = false;
        x = Camera.main.pixelWidth/2;
        y = btn.GetComponent<RectTransform>().rect.height/2;
        btn.transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked(){
        if(state==false){
            target.SetActive(true);
            state = true;
            btn.transform.position = new Vector2(target.transform.position.x,target.transform.position.y + target.GetComponent<RectTransform>().rect.height/2+y);
            // Debug.Log(target.GetComponent<RectTransform>().rect.height);
        }
        else{
            target.SetActive(false);
            state = false;
            btn.transform.position = new Vector2(x, y);
        }
    }
}
