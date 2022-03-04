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
    public GameObject itemName;
    public GameObject itemPrice;
    public GameObject itemImg;
    GameObject dontDestroy;
    public Dropdown m_Dropdown;
    int idx = -1;
    CashList data;
    void Start()
    {
        dontDestroy = GameObject.Find("DontDestroyObj");
        idx = dontDestroy.GetComponent<DontDestroy>().ndtIdx;
        data = LoadJsonFile<CashList>(Application.dataPath, "Script/Cash/ItemTemp");
        int tag = data.IL[idx].tag;
        int type = data.IL[idx].type;
        int price = data.IL[idx].price;
        string chance = data.IL[idx].chance;
        string img_name = data.IL[idx].img_name;
        string name = data.IL[idx].name;
        
        itemImg.GetComponent<Image>().sprite = Resources.Load("Image/CashShop/"+img_name, typeof(Sprite)) as Sprite;
        itemPrice.GetComponent<Text>().text = price+"";
        itemName.GetComponent<Text>().text = name;

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
}
