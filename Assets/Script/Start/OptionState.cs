using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionState : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isEnd = false;
    void Start()
    {
        
    }
    public void Exit(){
       isEnd = true; 
    }
    
    public IEnumerator ExitOption(){
        while (!isEnd){
            yield return new WaitForSeconds(0.1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
