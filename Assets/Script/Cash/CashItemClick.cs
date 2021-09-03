using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CashItemClick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel1, panel2;
    public GameObject panel1Image, panel1NameText, panel1TypeText, panel1ChanceText, panel1PriceText;
    public GameObject panel2Image, panel2NameText, panel2TypeText, panel2ChanceText, panel2PriceText;
    int idx = 0;
    CashList data;
    void Start()
    {
        data = LoadJsonFile<CashList>(Application.dataPath, "Script/Cash/ItemTemp");
        for(int i=0;i<data.IL.Count;i++){
            if(gameObject.name.Equals(data.IL[i].name)){
                idx = i;
                break;
            }
        }
        Debug.Log("idx: "+idx+"\ngameObject name: "+gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        // print("update");
    }

    public void ImBabo()
    {
        Debug.Log(gameObject.tag);
        if(gameObject.tag == "Selling"){
            if(panel1.activeSelf==true){
                panel1.SetActive(false);
            } else{
                panel2.SetActive(false);
                panel1.SetActive(true);
                // panel1Image.GetComponent<Image>().Sprite = Resources.Load<Sprite>("Image/CashShop/itemEx2");
                panel1PriceText.GetComponent<Text>().text = ""+data.IL[idx].price;
                panel1ChanceText.GetComponent<Text>().text = ""+data.IL[idx].chance;
                panel1TypeText.GetComponent<Text>().text = ""+data.IL[idx].type;
                panel1NameText.GetComponent<Text>().text = ""+data.IL[idx].name;
                panel1Image.GetComponent<Image>().sprite = Resources.Load("Image/CashShop/"+data.IL[idx].img_name, typeof(Sprite)) as Sprite;
            } 
        }
        else{
            if(panel2.activeSelf==true){
                panel2.SetActive(false);
            } else{
                panel1.SetActive(false);
                panel2.SetActive(true);
                panel2PriceText.GetComponent<Text>().text = ""+data.IL[idx].price;
                panel2ChanceText.GetComponent<Text>().text = ""+data.IL[idx].chance;
                panel2TypeText.GetComponent<Text>().text = ""+data.IL[idx].type;
                panel2NameText.GetComponent<Text>().text = ""+data.IL[idx].name;
                panel2Image.GetComponent<Image>().sprite = Resources.Load("Image/CashShop/"+data.IL[idx].img_name, typeof(Sprite)) as Sprite;
            } 
        }
    }

    T JsonToObject<T>(string json){
        return JsonUtility.FromJson<T>(json);
    }
    public T LoadJsonFile<T>(string loadPath, string fileName){
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.OpenOrCreate);
        
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }
}
