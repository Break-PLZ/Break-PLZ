using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertPrevent : MonoBehaviour
{
    // Start is called before the first frame updateS
    private bool isClicked = false;

    public void Clicked(){
        isClicked = true;
    }

    public IEnumerator decision(){
        while (!isClicked){
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

}
