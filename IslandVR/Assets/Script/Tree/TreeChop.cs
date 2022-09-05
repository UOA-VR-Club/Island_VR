using UnityEngine;
using System;

public class TreeChop : MonoBehaviour
{
    public int TreeHealthPoints = 500;
    public AudioSource TreeFallSound;
    public AudioSource CoconutChopSound;
    public AudioSource NormalChopSound;
    private readonly System.Random r = new System.Random();

    /// <summary>
    /// Called whenever a GameObject with Collision attribute hits tree.
    /// </summary>
    /// <param name="other">GameObject with Collision component.</param>
    private void OnCollisionEnter(Collision other)
    {
        // There is a 50% chance of coconut falling when the coconut tree is chopped
        if (r.Next(2) == 1)
        {
            CoconutDrop();
            CoconutChopSound.Play();
        }
        else
            NormalChopSound.Play();

        TreeHealthPoints = Math.Max(TreeHealthPoints - 100, 0);
        if (TreeHealthPoints == 0)
            TreeFall();
    }

    /// <summary>
    /// Drop a coconut from the tree (surprise)!
    /// </summary>
    private void CoconutDrop()
    {
        GameObject newCoconut = CreateCoconut();
        newCoconut.AddComponent<Rigidbody>();
    }

    /// <summary>
    /// Create a new Coconut GameObject.
    /// </summary>
    /// <returns>GameObject that is a new coconut.</returns>
    private GameObject CreateCoconut()
    {
        GameObject coconut = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        coconut.transform.parent = this.gameObject.transform;
        coconut.transform.localPosition = new Vector3((float)-0.87,(float)8.5,(float)-1.2);
        coconut.transform.localScale = new Vector3((float)0.85,(float)1,(float)0.8);
        return coconut;
    }

    private void TreeFall()
    {
        if (this.gameObject.GetComponent<Rigidbody>() != null) return;
        this.gameObject.AddComponent<Rigidbody>();
        TreeFallSound.Play();
    }
}
