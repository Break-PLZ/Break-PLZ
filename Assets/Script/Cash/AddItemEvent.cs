using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddItemEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ChanceItem;
    public GameObject PackageItem;
    public Transform parent;
    public Dropdown m_Dropdown;
    public GameObject itemName;
    public GameObject itemNum;
    public GameObject plusBtn;
    public GameObject prefab;
    public GameObject item;
    public GameObject itemName2;
    public GameObject itemNum2;
    public GameObject prefab2;
    public GameObject item2;
    public Transform parent2;
    public GameObject plusBtn2;
    int state;
    int y_package = 0;
    int y_rat = 0;
    void Start()
    {   
        if(m_Dropdown.value == 0){
            state = 0;
            ChanceItem.SetActive(true);
            PackageItem.SetActive(false);
        } else if(m_Dropdown.value == 1){
            state = 1;
            ChanceItem.SetActive(false);
            PackageItem.SetActive(true);
        } else if(m_Dropdown.value == 2){
            ChanceItem.SetActive(false);
            PackageItem.SetActive(false);
        }
        m_Dropdown.onValueChanged.AddListener(delegate{
            DropdownValueChanged(m_Dropdown);
        });
        plusBtn.GetComponent<Button>().onClick.AddListener(clickAddBtn);
        plusBtn2.GetComponent<Button>().onClick.AddListener(clickAddBtn2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropdownValueChanged(Dropdown change)
    {
        // change.value : text
        // 0 : chance
        // 1 : package
        // 2 : single
        if(change.value == 0){
            if(state == 1){
                ChanceItem.SetActive(true);
                PackageItem.SetActive(false);
            } else if(state == 2){
                ChanceItem.SetActive(true);
            }
            state = 0;
        } else if(change.value == 1){
            if(state == 0){
                ChanceItem.SetActive(false);
                PackageItem.SetActive(true);
            } else if(state == 2){
                PackageItem.SetActive(true);
            }
            state = 1;
        } else if(change.value == 2){
            if(state == 0){
                ChanceItem.SetActive(false);
            } else if(state == 1){
                PackageItem.SetActive(false);
            }
            state = 2;
        }
    }

    void clickAddBtn(){
        string name = itemName.GetComponent<Text>().text;
        string nums = itemNum.GetComponent<Text>().text;
        
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
        
        y_package ++; 
        Vector3 pos = prefab.transform.localPosition;
        pos.y = pos.y - 60f * y_package;
        tempInstance.transform.localPosition = pos;
        
        item.transform.GetChild(0).GetChild(0).gameObject.GetComponent<InputField>().text = "";
        item.transform.GetChild(1).GetChild(0).gameObject.GetComponent<InputField>().text = "";

        tempInstance.transform.GetChild(0).GetChild(0).gameObject.GetComponent<InputField>().text = name;
        tempInstance.transform.GetChild(1).GetChild(0).gameObject.GetComponent<InputField>().text = nums;
    }
    
    void clickAddBtn2(){
        string name = itemName2.GetComponent<Text>().text;
        string nums = itemNum2.GetComponent<Text>().text;
        
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
        
        GameObject tempInstance = Instantiate(prefab2, parent2);
        
        y_rat ++; 
        Vector3 pos = prefab2.transform.localPosition;
        pos.y = pos.y - 60f * y_rat;
        tempInstance.transform.localPosition = pos;
        
        item2.transform.GetChild(0).GetChild(0).gameObject.GetComponent<InputField>().text = "";
        item2.transform.GetChild(1).GetChild(0).gameObject.GetComponent<InputField>().text = "";

        tempInstance.transform.GetChild(0).GetChild(0).gameObject.GetComponent<InputField>().text = name;
        tempInstance.transform.GetChild(1).GetChild(0).gameObject.GetComponent<InputField>().text = nums;
    }
}
