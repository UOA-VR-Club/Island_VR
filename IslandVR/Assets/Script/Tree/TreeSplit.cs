using UnityEngine;
using System;
using Script.Tree;

public class TreeSplit : MonoBehaviour
{
    //sound effects
    [SerializeField] private AudioSource TreeFallSound;
    [SerializeField] private AudioSource CoconutChopSound;
    [SerializeField] private AudioSource NormalChopSound;
    
    // Item drops
    [SerializeField] private DroppableItem log;
    [SerializeField] private DroppableItem grub;
        
    // Tree health = 500
    [SerializeField] private int TreeHealthPoints;

    private readonly System.Random r = new System.Random();
    
    /// <summary>
    /// Called whenever a GameObject with Collision attribute hits tree.
    /// </summary>
    /// <param name="other">GameObject with Collision component.</param>
    private void OnCollisionEnter(Collision other)
    {
        this.GetComponent<CapsuleCollider>().radius = Math.Max(this.GetComponent<CapsuleCollider>().radius - (float) 0.04, (float) 0.05);

        // There is a 20% chance of coconut falling when the coconut tree is chopped
        if (r.Next(5) == 1)
            DropCoconut();
        else
            NormalChopSound.Play();

        TreeHealthPoints = Math.Max(TreeHealthPoints - 40, 0);
        if (TreeHealthPoints == 0)
        {
            SplitTree();
            log.DropItems();
            // There is a 20% chance of grubs generated
            if (r.Next(5) == 1)
                grub.DropItems();
        }
    }

    /// <summary>
    /// Drop a coconut from the tree (surprise)!
    /// </summary>
    private void DropCoconut()
    {
        try
        {
            GameObject Coconut = GetComponentInChildren<Item>().gameObject;
            if (Coconut != null)
            {
                Coconut.GetComponent<Rigidbody>().isKinematic = false;
                Coconut.GetComponent<Rigidbody>().useGravity = true;
                Coconut.transform.parent = null;
                CoconutChopSound.Play();
            }
        }
        catch (NullReferenceException exception)
        {
            Debug.Log(exception);
        }
    }

    private void SplitTree()
    {
        GameObject treeDown = this.transform.Find("palm_tree_bark_down").gameObject;
        GameObject treeUp = this.transform.Find("palm_tree_bark_up").gameObject;

        treeDown.GetComponent<Collider>().enabled = true;
        treeDown.transform.parent = null;

        treeUp.GetComponent<Collider>().enabled = true;
        treeUp.transform.parent = null;
        treeUp.GetComponent<Rigidbody>().isKinematic = false;

        TreeFallSound.Play();

        Destroy(this);
    }
}
