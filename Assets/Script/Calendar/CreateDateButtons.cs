using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateDateButtons : MonoBehaviour {

    public Transform dates;
    public GameObject day_texts;
    public GameObject date_button;
    public int month_num;           // 1 ~ 12
    public int first_day;           // 0 ~ 6: SUN ~ SAT

    void Start() {
        // Month
        Dictionary<int, int> months = new Dictionary<int, int>(){
            {1, 31}, {2, 28}, {3, 31}, {4, 30}, {5, 31}, {6, 30}, {7, 31}, {8, 31}, {9, 30}, {10, 31}, {11, 30}, {12, 31}
        };

        // y position setting
        float y_pos = 150;
        if(first_day == 0)  y_pos += 60;

        // create date buttons
        for(int i=0; i<months[month_num]; i++) {
            int cur_day = (first_day + i) % 7;
            float x_pos = day_texts.transform.GetChild(cur_day).transform.localPosition.x;
            if(cur_day == 0)    y_pos -= 60;
            Debug.Log(day_texts.transform.GetChild(cur_day).transform.localPosition);

            GameObject btn = GameObject.Instantiate(date_button, new Vector3(x_pos, y_pos, 0), new Quaternion(0, 0, 0, 0));
            btn.transform.SetParent(dates, false);
            btn.GetComponentInChildren<Text>().text = (i+1).ToString();
            btn.SetActive(true);
        }
    }
}
