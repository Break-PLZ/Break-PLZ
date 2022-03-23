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
    public GameObject ChanceItem;
    public GameObject PackageItem;
    public Dropdown m_Dropdown;
    Animator animator;
    int state;

    public GameObject itemName;
    public GameObject itemPrice;
    public GameObject AlertView;
    public GameObject AlertString;

    // Start is called before the first frame update
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

        animator = AlertView.GetComponent<Animator>();
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

    public void itemFin()
    {
        // 빈 칸이 있는지 확인
        bool isEmpty = false;
        int where = -1;
        string iName = itemName.GetComponent<Text>().text;
        string iPrice = itemPrice.GetComponent<Text>().text;
        if(iName.Length==0){
            isEmpty = true;
            where = 1;
        } else if(iPrice.Length==0){
            isEmpty = true;
            where = 2;
        } 
        
        // 빈칸이 있으면 아래 출력
        if(isEmpty){
            if(where == 1){
                AlertString.GetComponent<Text>().text = "이름을 입력해주세요.";
            } else{
                AlertString.GetComponent<Text>().text = "값을 입력해주세요.";
            }
            animator.SetTrigger("isEmpty");
            return;
        } else{
            int priceInt;
            bool priceNum = int.TryParse(iPrice, out priceInt);
            if(!priceNum){
                AlertString.GetComponent<Text>().text = "가격은 숫자여야 합니다.";
                animator.SetTrigger("isEmpty");
                return;
            }  
        }

        // 빈칸이 없으면 아래 실행
        addJsonData();
        SceneManager.LoadScene("CashScene");
    }

    void addJsonData(){
        string iName = itemName.GetComponent<Text>().text;
        string iPrice = itemPrice.GetComponent<Text>().text;
        int priceInt;
        bool priceNum = int.TryParse(iPrice, out priceInt);

        CashList cL = LoadJsonFile<CashList>(Application.dataPath, "Script/Cash/ItemTemp");
        CashClass new_class = new CashClass();
        new_class.name = iName;
        new_class.type = 1;
        new_class.chance = "확률형 아이템";
        if(m_Dropdown.value==1) new_class.chance = "패키지 아이템";
        else if(m_Dropdown.value == 2) new_class.chance = "단일 아이템";
        new_class.price = priceInt;
        new_class.img_name = "itemEx2";
        new_class.tag = 2;

        cL.IL.Add(new_class);

        string jsonData_ = ObjectToJson(cL);
        CreatetoJsonFile(Application.dataPath, "Script/Cash/ItemTemp", jsonData_);
        
    }   

    string ObjectToJson(object obj){
        return JsonUtility.ToJson(obj);
    }
    T JsonToObject<T>(string json){
        return JsonUtility.FromJson<T>(json);
    }

    void CreatetoJsonFile(string createPath, string filename, string jsonData){
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, filename), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    public T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.OpenOrCreate);
        
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }   
}
