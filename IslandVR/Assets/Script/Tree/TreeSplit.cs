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

        if (r.Next(5) == 1)
        {
            CoconutDrop();
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

    //drops the coconut (surprise!)
    private void CoconutDrop()
    {
        try
        {
            //make the coconut fall
            GameObject Coconut = GetComponentInChildren<Item>().gameObject;
            if(Coconut != null)
            {
                Coconut.GetComponent<Rigidbody>().isKinematic = false;
                Coconut.GetComponent<Rigidbody>().useGravity = true;
                Coconut.transform.parent = null;
                coconutChop.Play();
            }
        }
        catch (NullReferenceException n){
            NullReferenceException error = n;
        }
    }

    //take a wild guess 
    private void SplitTree()
    {
        GameObject treeDown = this.transform.Find("palm_tree_bark_down").gameObject;
        GameObject treeUp = this.transform.Find("palm_tree_bark_up").gameObject;

        treeDown.GetComponent<Collider>().enabled = true;
        treeDown.transform.parent = null;

        treeUp.GetComponent<Collider>().enabled = true;
        treeUp.transform.parent = null;
        treeUp.GetComponent<Rigidbody>().isKinematic = false;

        Destroy(this);
    }
}
