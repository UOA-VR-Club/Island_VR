using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.transform.parent = null;
    }
}
