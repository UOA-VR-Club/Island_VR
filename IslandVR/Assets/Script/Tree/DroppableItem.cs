using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Tree
{
    public class DroppableItem : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int maxItems;

        private IList<GameObject> items = new List<GameObject>();

        public void DropItems()
        {
            SpawnItems();
            foreach (var item in items)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().useGravity = true;
                item.transform.parent = null;
            }
        }

        private void SpawnItems()
        {
            var numberOfItems = Random.Range(1, maxItems);
            for (int i = 0; i < numberOfItems; i++)
            {
                GameObject log = Instantiate(prefab, transform.position, Quaternion.identity);
                log.AddComponent<Rigidbody>();
                items.Add(log);
            }
        }
    }
}