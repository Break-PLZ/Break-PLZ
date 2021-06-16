using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeftMoneyScript : MonoBehaviour
{

    public Text LeftMoney;
    public int money;
    // Start is called before the first frame update
    void Start()
    {
        money = 500;
        LeftMoney.text = "$"+ money;
    }

    // Update is called once per frame
    void Update()
    {
        LeftMoney.text = "$"+ money;
    }
}
