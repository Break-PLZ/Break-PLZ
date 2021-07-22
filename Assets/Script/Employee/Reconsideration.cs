using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reconsideration : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPause = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown(){
        if(isPause){
            Time.timeScale = 1;
            isPause = false;
        }
        else{
            Time.timeScale = 0;
            isPause = true;
        }
    }

}
