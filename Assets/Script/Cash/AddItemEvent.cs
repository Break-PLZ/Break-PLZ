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
    public Dropdown m_Dropdown;
    int state;
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
}
