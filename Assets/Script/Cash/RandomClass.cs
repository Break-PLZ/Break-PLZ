using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class RandomClass
{
    public string name;
    public int num;


    // Start is called before the first frame update
    public void SetProperty(RandomClass rand){
        name = rand.name;
        num = rand.num;
    }

    public void InitProperty(){
        name = "test_name_"+Random.Range(0, 101);
        num = Random.Range(0,100);
    }
    
    public void TestMethod(){
        Debug.Log("hihi "+name);
    }

    public void Print()
    {
        Debug.Log("name = " + name);
        Debug.Log("num = " + num);
    }

}
