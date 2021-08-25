using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingAddItemScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void itemAdd()
    {
        SceneManager.LoadScene("AddItemScene");
    }
    
    public void itemEdit()
    {
        SceneManager.LoadScene("AddItemScene");
    }

    public void itemFin()
    {
        Debug.Log("cccc");
        SceneManager.LoadScene("CashScene");
    }
}
