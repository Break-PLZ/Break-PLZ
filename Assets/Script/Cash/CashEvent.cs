using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CashEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab1;
    public GameObject prefab2;
    public Transform parent;
    Button[] instances;
    int itemCnt;
    CashList data;

    int idx = -1;

    public GameObject panel1, panel2;
    void Start()
    {
        // GameObject myInstance = Instantiate(prefab, parent);
        // int[] posX = new int[]{-256, -128, 0, 128, 256};
        float[] posX = new float[]{-457.5f, -305.0f, -152.5f, 0.0f, 152.5f, 305.0f, 457.5f};
        // float posY = 181;
        float posY = 307.5f;
        data = LoadJsonFile<CashList>(Application.dataPath, "Script/Cash/ItemTemp");
        itemCnt = data.IL.Count;
        instances = new Button[itemCnt];
        Debug.Log("itemCnt: " + itemCnt);
        for(int i=0;i<itemCnt;i++){
            float objX = posX[i%7];
            int row = i/7;
            float row_float = (float)row;
            float objY = posY - row_float * 152.5f;
            if(data.IL[i].tag == 1){
                //Button tempInstance = Instantiate(prefab1, parent);
                GameObject tempInstance = Instantiate(prefab1, parent);
                SetChild(tempInstance, objX, objY, "Image/CashShop/"+data.IL[i].img_name);
                int tag = data.IL[i].tag;
                int type = data.IL[i].type;
                int price = data.IL[i].price;
                string chance = data.IL[i].chance;
                string img_name = data.IL[i].img_name;
                string name = data.IL[i].name;
                int index = i;
                tempInstance.GetComponent<Button>().onClick.AddListener(() => openPanel(tag, type, price, chance, img_name, index, name));
                Debug.Log(tempInstance);
                // tempInstance.onClick.AddListener(openPanel);
            } else if(data.IL[i].tag == 2){
                GameObject tempInstance = Instantiate(prefab2, parent);
                SetChild(tempInstance, objX, objY, "Image/CashShop/"+data.IL[i].img_name);
                int tag = data.IL[i].tag;
                int type = data.IL[i].type;
                int price = data.IL[i].price;
                string chance = data.IL[i].chance;
                string img_name = data.IL[i].img_name;
                string name = data.IL[i].name;
                int index = i;
                tempInstance.GetComponent<Button>().onClick.AddListener(() => openPanel(tag, type, price, chance, img_name, index, name));
            }        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public T LoadJsonFile<T>(string loadPath, string fileName){
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.OpenOrCreate);
        
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }

    public void SetChild(GameObject parent, float objX, float objY, string resourceName){
        // Vector3 position = parent.transform.localPosition;
        // position.x = objX;
        // position.y = objY;
        // parent.transform.localPosition = position;
        GameObject imageObj = parent.transform.GetChild(0).gameObject;
        imageObj.GetComponent<Image>().sprite = Resources.Load(resourceName, typeof(Sprite)) as Sprite;
    }

    public void openPanel(int tag, int type, int price, string chance, string img_name, int index, string name)
    {   
        Debug.Log("index: " + index + " and idx: " + idx);
        if(tag==1){
            if(panel1.activeSelf == true && index == idx){
                panel1.SetActive(false);
            } else{
                if(panel2.activeSelf == true){
                    panel2.SetActive(false);
                }
                panel1.SetActive(true);
                idx = index;
                panel1.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load("Image/CashShop/"+img_name, typeof(Sprite)) as Sprite;
                panel1.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = name;
                panel1.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = ""+type;
                panel1.transform.GetChild(3).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = chance;
                panel1.transform.GetChild(4).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = ""+price;
            }
            
        } else if(tag==2){
            if(panel2.activeSelf == true && index == idx){
                panel2.SetActive(false);
            } else{
                if(panel1.activeSelf == true){
                    panel1.SetActive(false);
                }
                panel2.SetActive(true);
                idx = index;
                panel2.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load("Image/CashShop/"+img_name, typeof(Sprite)) as Sprite;
                panel2.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = name;
                panel2.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = ""+type;
                panel2.transform.GetChild(3).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = chance;
                panel2.transform.GetChild(4).GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = ""+price;
            }
        }
    }
}
