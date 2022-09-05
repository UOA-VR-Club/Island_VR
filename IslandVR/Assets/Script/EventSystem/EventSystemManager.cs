using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemManager : MonoBehaviour
{
    public bool isAnyPaneActive = false;
    public GameObject EventSystem;

    public void DeactivateAllPanes(){
        foreach (PaneEvoker i in EventSystem.GetComponents<PaneEvoker>())
        {
            i.isPaneActive = false;
            i.Pane.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
