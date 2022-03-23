using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PackageAddBtnEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public Text itemName;
    public Text itemNum;
    public GameObject prefab;
    public GameObject item;
    public Transform parent;
    public int listNum = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPackage(){
        string name = itemName.text;
        string nums = itemNum.text;
        
        if(name == "" || nums == ""){
            Debug.Log("빈칸있어!!");
            return;
        }
        int priceInt;
        bool priceNum = int.TryParse(nums, out priceInt);
        if(!priceNum){
            Debug.Log("개수 숫자여야함!!");
            return;
        }
        Debug.Log("name: " + name + " and num : " + nums);

        GameObject tempInstance = Instantiate(prefab, parent);
        listNum ++;

        Vector3 pos = prefab.transform.localPosition;
        pos.y = pos.y - 60f * listNum;
        tempInstance.transform.localPosition = pos;

        tempInstance.transform.GetChild(0).GetChild(0).gameObject.GetComponent<InputField>().text = name;
        tempInstance.transform.GetChild(1).GetChild(0).gameObject.GetComponent<InputField>().text = nums;

        item.transform.GetChild(0).GetChild(0).gameObject.GetComponent<InputField>().text = "";
        item.transform.GetChild(1).GetChild(0).gameObject.GetComponent<InputField>().text = "";
    }
}
