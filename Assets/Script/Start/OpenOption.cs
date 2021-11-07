using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOption : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterOption(){
        StartCoroutine(RunOption());
    }
    IEnumerator RunOption(){
        GameObject OptionScreen = Instantiate(Resources.Load("Prefabs/Option"),GameObject.FindWithTag("Background").transform) as GameObject;
        yield return StartCoroutine(OptionScreen.GetComponent<OptionState>().ExitOption());
        Destroy(OptionScreen);
    }
}
