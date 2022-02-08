using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovingAddItemScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemName;
    public GameObject itemPrice;
    public Dropdown m_Dropdown;
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
        // Debug.Log("cccc");
        // 빈 칸이 있는지 확인
        bool isEmpty = false;
        int where = -1;

        // 빈칸이 있으면 아래 출력

        // 빈칸이 있으면 아래 실행
        addJsonData();
        SceneManager.LoadScene("CashScene");
    }

    void addJsonData(){
        CashList cL = LoadJsonFile<CashList>(Application.dataPath, "Script/Cash/ItemTemp");

        CashClass new_class = new CashClass();
        new_class.name = "itemSample";
        new_class.type = 1;
        new_class.chance = "확률형 아이템";
        if(m_Dropdown.value==1) new_class.chance = "패키지 아이템";
        else if(m_Dropdown.value == 2) new_class.chance = "단일 아이템";
        new_class.price = 40;
        new_class.img_name = "itemEx2";
        new_class.tag = 1;

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
