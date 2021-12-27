using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Worker
{
    public int cost; // cost of worker
    public int server;
    public int client;
    public int graphic;
    public int sound;
    public string name;
    public string img_name;
    public List<string> talent;

    // Start is called before the first frame update
}
