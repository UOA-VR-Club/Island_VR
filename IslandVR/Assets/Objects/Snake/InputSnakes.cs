using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSnakes : MonoBehaviour
{
    public GameObject snakeProfab;
    public int snakenumber;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= snakenumber; i++)
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            Vector3 snakeRangeSize = boxCollider.size;
            Vector3 snakeRangePos = this.transform.position;
            float randomx = Random.Range((float)(snakeRangePos.x-0.5 * snakeRangeSize.x), (float)(snakeRangePos.x + 0.5 * snakeRangeSize.x));
            float randomz = Random.Range((float)(snakeRangePos.z - 0.5 * snakeRangeSize.z), (float)(snakeRangePos.z + 0.5 * snakeRangeSize.z));
            Vector3 snakepos = new Vector3(randomx, snakeRangePos.y, randomz);
            float randomy = Random.Range(0, 360);
            Quaternion snakerot = new Quaternion(0, randomy, 0, 0);
            GameObject node = Object.Instantiate(snakeProfab, snakepos, snakerot, null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
