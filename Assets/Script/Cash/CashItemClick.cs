using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashItemClick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel1, panel2;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // print("update");
    }

    public void ImBabo()
    {
        Debug.Log(gameObject.tag);
        if(gameObject.tag == "Selling"){
            if(panel1.activeSelf==true){
                panel1.SetActive(false);
            } else{
                panel2.SetActive(false);
                panel1.SetActive(true);
            } 
        }
        else{
            if(panel2.activeSelf==true){
                panel2.SetActive(false);
            } else{
                panel1.SetActive(false);
                panel2.SetActive(true);
            } 
        }
        
    }
}
