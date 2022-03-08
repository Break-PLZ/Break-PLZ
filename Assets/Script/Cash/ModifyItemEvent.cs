using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModifyItemEvent : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject itemName;
    public InputField itemName;
    public InputField itemPrice;
    public GameObject itemImg;
    GameObject dontDestroy;
    public Dropdown m_Dropdown;
    public Button finBtn;
    int idx = -1;
    CashList data;
    public GameObject AlertView;
    public GameObject AlertString;
    Animator animator;
    void Start()
    {
        animator = AlertView.GetComponent<Animator>();
        // initiate inputField from json (using dontdestroy object -> idx : json seq);
        dontDestroy = GameObject.Find("DontDestroyObj");
        idx = dontDestroy.GetComponent<DontDestroy>().ndtIdx;
        data = LoadJsonFile<CashList>(Application.dataPath, "Script/Cash/ItemTemp");
        int tag = data.IL[idx].tag;
        int type = data.IL[idx].type;
        int price = data.IL[idx].price;
        string chance = data.IL[idx].chance;
        string img_name = data.IL[idx].img_name;
        string name = data.IL[idx].name;
        
        itemName.text = name;
        itemPrice.text = price+"";
        itemImg.GetComponent<Image>().sprite = Resources.Load("Image/CashShop/"+img_name, typeof(Sprite)) as Sprite;

        // finBtn add onClick Listener
        finBtn.onClick.AddListener(clickFin);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void clickFin(){
        bool isEmpty = false;
        int where = -1;
        string iName = itemName.text;
        string iPrice = itemPrice.text;
        int priceInt;

        // check if Empty
        if(iName.Length==0){
            isEmpty = true;
            where = 1;
        } else if(iPrice.Length==0){
            isEmpty = true;
            where = 2;
        } 
        
        // if Empty
        if(isEmpty){
            if(where == 1){
                AlertString.GetComponent<Text>().text = "이름을 입력해주세요.";
            } else{
                AlertString.GetComponent<Text>().text = "값을 입력해주세요.";
            }
            animator.SetTrigger("isEmpty");
            return;
        } else{
            bool priceNum = int.TryParse(iPrice, out priceInt);
            if(!priceNum){
                AlertString.GetComponent<Text>().text = "가격은 숫자여야 합니다.";
                animator.SetTrigger("isEmpty");
                return;
            }  
        }

        // not Empty
        modifyJsonData(iName, priceInt);
        Destroy(dontDestroy);
        SceneManager.LoadScene("CashScene");
    }

    void modifyJsonData(string iName, int iPrice){
        CashList cL = LoadJsonFile<CashList>(Application.dataPath, "Script/Cash/ItemTemp");
        cL.IL[idx].name = iName;
        cL.IL[idx].price = iPrice;

        string jsonData_ = ObjectToJson(cL);
        CreatetoJsonFile(Application.dataPath, "Script/Cash/ItemTemp", jsonData_);
    }
}
