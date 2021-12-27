using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Managers : MonoBehaviour
{
    // Start is called before the first frame update
    public WorkerList temp;
    public void WorkerContents(GameObject obj,int i){
        obj.AddComponent<ShowTalents>();
        workerstatus ws = obj.AddComponent<workerstatus>();
        ws.InitProperty();
        ws.SetProperty(temp.WL[i]);
        ws.showStatus(obj);
    }
    
}
