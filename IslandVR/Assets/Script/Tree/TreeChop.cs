using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Script.Tree
{
    public class TreeChop : MonoBehaviour
    {
        [SerializeField] protected GameObject treeStub;
        [SerializeField] protected GameObject upperTree;
        
        //sound effects
        [SerializeField] protected AudioSource treeFallSound;
        [SerializeField] protected AudioSource coconutChopSound;
        [SerializeField] protected AudioSource normalChopSound;
        
        // Tree health = 500
        [SerializeField] protected int treeHealthPoints;
        //Remove tree object after 8 seconds
        [SerializeField] protected float destroyTime;
        //When tress falls, how much force will be applied
        [SerializeField] protected float destroyForce;
        
        private readonly System.Random r = new System.Random();

        /// <summary>
        /// Called whenever a GameObject with Collision attribute hits tree.
        /// </summary>
        /// <param name="other">GameObject with Collision component.</param>
        private void OnCollisionEnter(Collision other)
        {
            Vector3 position = other.transform.position;
            // There is a 50% chance of coconut falling when the coconut tree is chopped
            if (r.Next(2) == 1)
            {
                DropCoconut();
                coconutChopSound.Play();
            }
            else
                normalChopSound.Play();

            treeHealthPoints = Math.Max(treeHealthPoints - 100, 0);
            if (treeHealthPoints == 0)
            {
                TreeFall();
                DropLogs(position);
            }
        }
        
        /// <summary>
        /// Drop a coconut from the tree (surprise)!
        /// </summary>
        private void DropCoconut()
        {
            GameObject newCoconut = CreateCoconut();
            newCoconut.AddComponent<Rigidbody>();
        }
        
        private void DropLogs(Vector3 position)
        {
            var newLogs = CreateLogs(position);
            foreach (var log in newLogs)
            {
                log.AddComponent<Rigidbody>();
            }
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
        
        private IEnumerable<GameObject> CreateLogs(Vector3 position)
        {
            var logs = new List<GameObject>();
            // Randomise the number of logs 
            var numberOfLogs = r.Next(1,3);
            for (var i = 0; i < numberOfLogs; i++)
            {
                var log = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                log.transform.parent = this.gameObject.transform;
                log.transform.localPosition = position; 
                log.transform.localScale = position;
                logs.Add(log);
            }
        
            return logs;
        }
        
        private void TreeFall()
        {
            if (this.gameObject.GetComponent<Rigidbody>() != null) return;
            var tree = this.gameObject.AddComponent<Rigidbody>();
        
            treeFallSound.Play();
            var randomForce = Random.Range(-destroyForce, destroyForce);
            tree.AddForce(randomForce, 0f, randomForce);
            Destroy(this.gameObject, destroyTime);
        }
    }
}
