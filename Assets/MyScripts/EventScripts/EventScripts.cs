using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScripts : MonoBehaviour
{
    Button gg;
    // Start is called before the first frame update
    void Start()
    {
        gg.onClick.AddListener(FFF);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FFF()
    {

    }
}
