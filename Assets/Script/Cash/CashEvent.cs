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
    GameObject[] instances;
    int itemCnt;
    CashList data;
    void Start()
    {
        // GameObject myInstance = Instantiate(prefab, parent);
        int[] posX = new int[]{-256, -128, 0, 128, 256};
        int posY = 181;
        data = LoadJsonFile<CashList>(Application.dataPath, "Script/Cash/ItemTemp");
        itemCnt = data.IL.Count;
        instances = new GameObject[itemCnt];
        Debug.Log("itemCnt: " + itemCnt);
        for(int i=0;i<itemCnt;i++){
            int objX = posX[i%5];
            int objY = posY - (i/5) * 128;
            if(data.IL[i].tag == 1){
                GameObject tempInstance = Instantiate(prefab1, parent);          
                // Vector3 position = tempInstance.transform.localPosition;
                // position.x = objX;
                // position.y = objY;
                // tempInstance.transform.localPosition = position;
                // tempInstance.GetChild(0).GetComponent<Image>().sprite = Resources.Load("Image/CashShop/"+data.IL[i].img_name, typeof(Sprite)) as Sprite;
                SetChild(tempInstance, objX, objY, "Image/CashShop/"+data.IL[i].img_name);
            } else if(data.IL[i].tag == 2){
                GameObject tempInstance = Instantiate(prefab2, parent);
                // Vector3 position = tempInstance.transform.localPosition;
                // position.x = objX;
                // position.y = objY;
                // tempInstance.transform.localPosition = position;
                SetChild(tempInstance, objX, objY, "Image/CashShop/"+data.IL[i].img_name);
                // tempInstance.GetChild(0).GetComponent<Image>().sprite = Resources.Load("Image/CashShop/"+data.IL[i].img_name, typeof(Sprite)) as Sprite;
            }        
            
            
            // panel1Image.GetComponent<Image>().sprite = Resources.Load("Image/CashShop/"+data.IL[idx].img_name, typeof(Sprite)) as Sprite;
        }
        // Debug.Log("idx: "+idx+"\ngameObject name: "+gameObject.name);
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

    public void SetChild(GameObject parent, int objX, int objY, string resourceName){
        Vector3 position = parent.transform.localPosition;
        position.x = objX;
        position.y = objY;
        parent.transform.localPosition = position;
        // Debug.Log(parent.GetChild(0).name);
        GameObject imageObj = parent.transform.GetChild(0).gameObject;
        imageObj.GetComponent<Image>().sprite = Resources.Load(resourceName, typeof(Sprite)) as Sprite;
        // GameObject imageObj = parent.GetComponent("Item");
        // imageObj.GetComponent<Image>().sprite = Resource.Load(resourceName, typeof(Sprite)) as Sprite;
    }


}
