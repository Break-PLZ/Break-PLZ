using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    Managers managers;
    public static GameManager Instance
    {
        get {
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }// Start is called before the first frame update

    
    public void gotoSetMonth(){
        GameObject obj;
        if(SceneManager.GetActiveScene().name=="EmployeeScene"){
            obj = GameObject.Find("EmployeeManager");
            managers = obj.GetComponent<EmployeeManager>();
        }
        else if(SceneManager.GetActiveScene().name=="WorkerManagementScene"){
            obj = GameObject.Find("WorkerManager");
            managers = obj.GetComponent<WorkerManager>();
        }    
        string jsonData = ObjectToJson(managers.temp);
        CreatetoJsonFile(Application.dataPath,"Script/EmployeeTemp",jsonData);
        SceneManager.LoadScene("SetMonthScene");
    }
    public void gotoSetEmployee(){
        SceneManager.LoadScene("EmployeeScene");
    }
    public void gotoWorkerManagement(){
        SceneManager.LoadScene("WorkerManagementScene");
    }
    void Start()
    {
        
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
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }
}
