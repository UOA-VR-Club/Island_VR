using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public LineRenderer line;

    public Transform currentPos;

    public Transform lurePos;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, currentPos.localPosition);
        line.SetPosition(1, lurePos.localPosition);
        Debug.Log("CurrentPos:"+ currentPos.position);
        

    }
}
