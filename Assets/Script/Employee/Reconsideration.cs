using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reconsideration : MonoBehaviour
{
    // Start is called before the first frame updateS
    private bool isClicked = false;
    public bool result = false;
    GameObject title, cost, status;
    GameObject contents;
    GameObject img;
    string title_text,status_text,cost_text,contents_text,img_name; 
    public void Clicked(){
        isClicked = true;
    }
    public void Yes(){
       result = true; 
    }
    public IEnumerator decision(){
        while (!isClicked){
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Start()
    {
        title = GameObject.Find("info").transform.Find("name").gameObject;
        status = GameObject.Find("info").transform.Find("status").gameObject;
        cost = GameObject.Find("info").transform.Find("cost").gameObject;
        img = GameObject.Find("info").transform.Find("Image").gameObject;
        contents = GameObject.Find("contents").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        title.GetComponent<Text>().text = title_text;
        cost.GetComponent<Text>().text = cost_text;
        status.GetComponent<Text>().text = status_text;
        img.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/EmployeeScene/"+img_name);
        contents.GetComponent<Text>().text = contents_text;
    }
    public void setcontents(string title_text, string cost_text, string status_text, string contents_text, string img_name){
        this.title_text = title_text;
        this.cost_text = cost_text;
        this.status_text = status_text;
        this.contents_text = contents_text;
        this.img_name = img_name;
    }
}
