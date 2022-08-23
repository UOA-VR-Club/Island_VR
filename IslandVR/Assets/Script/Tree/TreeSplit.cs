using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TreeSplit : MonoBehaviour
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
        this.GetComponent<CapsuleCollider>().radius = Math.Max(this.GetComponent<CapsuleCollider>().radius - (float) 0.04, (float) 0.05);
        Debug.Log("tree hit.");

        if (r.Next(5) == 1)
        {
            CoconutDrop();
            coconutChop.Play();
        } 
        else
        {
            normalChop.Play();
        }
        healthPoints = Math.Max(healthPoints - 40, 0);
        if(healthPoints == 0)
        {
            SplitTree();
        }
    }


    /*
    private GameObject createCoconut()
    {
        GameObject coconut = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        coconut.transform.parent = this.gameObject.transform;
        coconut.transform.localPosition = new Vector3((float)-0.87,(float)8.5,(float)-1.2);
        coconut.transform.localScale = new Vector3((float)0.85,(float)1,(float)0.8);
        return coconut;
    }
    */
    
    //drops the coconut (surprise!)
    private void CoconutDrop()
    {
        try
        {
            //make the coconut fall
            GameObject Coconut = GetComponentInChildren<Item>().gameObject;
            if(Coconut != null)
            {
                if(Coconut.GetComponent<Rigidbody>() == null)
                {
                    Coconut.AddComponent<Rigidbody>();
                }

                Coconut.GetComponent<Rigidbody>().useGravity = true;
                
                Coconut.transform.parent = null;
            }
        }
        catch (NullReferenceException n){
            NullReferenceException error = n;
        }
    }

    //take a wild guess 
    private void SplitTree()
    {
        /*
        if(this.gameObject.GetComponent<Rigidbody>() == null)
        {
            this.gameObject.AddComponent<Rigidbody>();
            treeFall.Play();
        }
        */
        GameObject treeDown = this.transform.Find("palm_tree_bark_down").gameObject;
        GameObject treeUp = this.transform.Find("palm_tree_bark_up").gameObject;

        treeDown.GetComponent<Collider>().enabled = true;
        treeDown.transform.parent = null;

        treeUp.GetComponent<Collider>().enabled = true;
        treeUp.transform.parent = null;
        treeUp.AddComponent<Rigidbody>();

        Destroy(this);
    }
}
