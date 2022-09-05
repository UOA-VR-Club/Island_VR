using UnityEngine;

public class CoconutDrop : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.transform.parent = null;
    }
}
