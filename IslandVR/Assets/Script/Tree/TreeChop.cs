using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreeChop : MonoBehaviour
{
    public int healthPoints = 500;
    private System.Random r = new System.Random();
    public AudioSource treeFall;
    public AudioSource coconutChop;
    public AudioSource normalChop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //called whenever collider hits tree
    private void OnCollisionEnter(Collision other)
    {
        if(r.Next(2) == 1)
        {
            CoconutDrop();
            coconutChop.Play();
        } 
        else
        {
            normalChop.Play();
        }
        healthPoints = Math.Max(healthPoints-100,0);
        if(healthPoints == 0)
        {
            TreeFall();
        }
    }



    private GameObject createCoconut()
    {
        GameObject coconut = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        coconut.transform.parent = this.gameObject.transform;
        coconut.transform.localPosition = new Vector3((float)-0.87,(float)8.5,(float)-1.2);
        coconut.transform.localScale = new Vector3((float)0.85,(float)1,(float)0.8);
        return coconut;
    }
    
    //drops the coconut (surprise!)
    private void CoconutDrop()
    {
        //make the coconut fall
        GameObject newCoconut = createCoconut();
        newCoconut.AddComponent<Rigidbody>();
    }

    //take a wild guess 
    private void TreeFall()
    {
        if(this.gameObject.GetComponent<Rigidbody>() == null)
        {
            this.gameObject.AddComponent<Rigidbody>();
            treeFall.Play();
        }
    }
}
