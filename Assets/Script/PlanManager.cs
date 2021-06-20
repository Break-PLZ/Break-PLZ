using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void gotoSetMonth(){
        SceneManager.LoadScene("SetMonthScene");
    }
    public void gotoSetEmployee(){
        SceneManager.LoadScene("EmployeeScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
