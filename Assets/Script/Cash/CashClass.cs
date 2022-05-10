using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CashClass
{
    public string name;
    public int type;
    public string chance;
    public int price;
    public string img_name;
    public int tag;
    public int random_type;
    public List<RandomClass> RL;

    // Start is called before the first frame update
    public void SetProperty(CashClass cash){
        name = cash.name;
        type = cash.type;
        chance = cash.chance;
        price = cash.price;
        img_name = cash.img_name;
        tag = cash.tag;
        random_type = cash.random_type;
        RL = cash.RL;
    }

    public void InitProperty(){
        name = "test_name_"+Random.Range(0, 101);
        type = Random.Range(0,2);
        chance = "test_chance_"+ Random.Range(0, 101);
        price = Random.Range(1, 51);
        img_name = "itemEx2";
        tag = 1;
        random_type = 1;
        RL = new List<RandomClass>();
    }
    
    public void TestMethod(){
        Debug.Log("hihi "+img_name);
    }

    public void Print()
    {
        Debug.Log("name = " + name);
        Debug.Log("type = " + type);
        Debug.Log("chance = " + chance);
        Debug.Log("price = " + price);
        Debug.Log("img_name = " + img_name);
        Debug.Log("tag = " + tag);
    }

}
