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
    int itemCnt;
    CashList data;
    List<GameObject> prefabs;
    List<int> indexList;
    int itemIdx = -1;
    public GameObject dontDestroy;
    int idx = -1;
    public Button addBtn, modBtn;
    public GameObject panel1, panel2;

    // for Delete Item
    public Button delBtn1, delBtn2;
    public GameObject delPanel;
    public Button yesBtn, noBtn;
    public GameObject warnText;

    async void Start()
    {
        prefabs = new List<GameObject>();
        indexList = new List<int>();

        data = LoadJsonFile<CashList>(Application.dataPath, "Script/Cash/ItemTemp");
        itemCnt = data.IL.Count;

        for(int i=0;i<itemCnt;i++){
            if(data.IL[i].tag == 1){
                GameObject tempInstance = Instantiate(prefab1, parent);
                SetChild(tempInstance, "Image/CashShop/"+data.IL[i].img_name);
                int tag = data.IL[i].tag;
                int type = data.IL[i].type;
                int price = data.IL[i].price;
                string chance = data.IL[i].chance;
                string img_name = data.IL[i].img_name;
                string name = data.IL[i].name;
                int index = i;
                tempInstance.GetComponent<Button>().onClick.AddListener(() => openPanel(tag, type, price, chance, img_name, index, name));
                prefabs.Add(tempInstance);
                indexList.Add(index);
            } else if(data.IL[i].tag == 2){
                GameObject tempInstance = Instantiate(prefab2, parent);
                SetChild(tempInstance, "Image/CashShop/"+data.IL[i].img_name);
                int tag = data.IL[i].tag;
                int type = data.IL[i].type;
                int price = data.IL[i].price;
                string chance = data.IL[i].chance;
                string img_name = data.IL[i].img_name;
                string name = data.IL[i].name;
                int index = i;
                tempInstance.GetComponent<Button>().onClick.AddListener(() => openPanel(tag, type, price, chance, img_name, index, name));
                prefabs.Add(tempInstance);
                indexList.Add(index);
            }        
        }
        addBtn.onClick.AddListener(itemAdd);
        modBtn.onClick.AddListener(itemModify);
        delBtn1.onClick.AddListener(itemDel);
        delBtn2.onClick.AddListener(itemDel);
        yesBtn.onClick.AddListener(itemDelYes);
        noBtn.onClick.AddListener(itemDelNo);
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

    public void SetChild(GameObject parent, string resourceName){
        GameObject imageObj = parent.transform.GetChild(0).gameObject;
        imageObj.GetComponent<Image>().sprite = Resources.Load(resourceName, typeof(Sprite)) as Sprite;
    }

    public void openPanel(int tag, int type, int price, string chance, string img_name, int index, string name)
    {   
        itemIdx = indexList[index];
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


    public void itemAdd(){
        SceneManager.LoadScene("AddItemScene");
    }
    
    public void itemModify(){
        dontDestroy.GetComponent<DontDestroy>().ndtIdx = itemIdx;
        
        DontDestroyOnLoad(dontDestroy);
        SceneManager.LoadScene("ModifyItemScene");
    }

    public void itemDel(){
        delPanel.SetActive(true);
        // Debug.Log(warnText.GetComponent<Text>().text);
        warnText.GetComponent<Text>().text = "[" + data.IL[itemIdx].name + "] 아이템을 정말 삭제하시겠습니까?";
    }

    public async void itemDelYes(){
        data.IL.RemoveAt(itemIdx);
        Destroy(prefabs[itemIdx]);
        prefabs.RemoveAt(itemIdx);
        for(int i= itemIdx; i<indexList.Count;i++){
            indexList[i]--;
        }
        string jsonData_ = ObjectToJson(data);
        CreatetoJsonFile(Application.dataPath, "Script/Cash/ItemTemp", jsonData_);

        panel1.SetActive(false);
        panel2.SetActive(false);
        delPanel.SetActive(false);
    }
    public void itemDelNo(){
        delPanel.SetActive(false);
    }
}
