using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsOverwrite : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cause;
    public Button yesbtn;
    void Start()
    {
        cause = GameObject.Find("SelectMenu").transform.Find("CauseScreen").gameObject;
        yesbtn = cause.transform.Find("Panel").transform.Find("Yes").GetComponent<Button>();
        yesbtn.onClick.AddListener(this.gameObject.GetComponent<SelectGameManager>().gamemanager.GetComponent<GameManager>().gotoSetEmployee);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCaution(){
        cause.SetActive(true);
    }
}
