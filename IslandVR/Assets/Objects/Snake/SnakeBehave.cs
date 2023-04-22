using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SnakeBehave : MonoBehaviour
{
    private string targetName;
    private float snakeTracking;
    private float snakeLowSpeed;
    private float snakeHighSpeed;
    private float snakeRotSpeed;
    private bool Snakemoving;
    private bool SnakeEscape;
    private int attackSilence;
    private int timer;
    public Animator snakeAnim;
    public GameObject snakeActRange;
    private BoxCollider snakeRangeCollider;

    
    public GameObject snakebody;


    // Start is called before the first frame update
    void Start()
    {
        targetName = "SnakeTarget";
        snakeTracking = 12f;
        snakeLowSpeed = 0.01f;
        snakeHighSpeed = 0.02f;
        snakeRotSpeed = 0.4f;
        Snakemoving = true;
        SnakeEscape = false;
        attackSilence = 700; //should be larger than 700
        timer = attackSilence;
        snakeRangeCollider = snakeActRange.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Make a judgement according to the distence between snake and enimy
        Vector3 snakepos = this.transform.localPosition;
        GameObject snaketarget = GameObject.Find(targetName);
        float enemydistance = Vector3.Distance(this.transform.position, snaketarget.transform.position);
        if (enemydistance <= snakeTracking && Snakemoving == true)
        {
            //Rotate the direction of snake
            Vector3 direction = snaketarget.transform.position - this.transform.position;
            if (SnakeEscape == true)
            {
                direction = direction * (-1);
            }
            Vector3 forward = transform.forward;
            float angle = Vector3.Angle(forward, direction);
            Vector3 cross = Vector3.Cross(forward, direction);
            if (angle >= snakeRotSpeed)
            {
                transform.Rotate(cross, snakeRotSpeed);
            }
            else
            {
                transform.Rotate(cross, angle);
            }

            //if the direction is suitable, play attack animation and stop moving
            if (enemydistance < 3.2 && SnakeEscape == false && timer >= attackSilence && angle < 30 * snakeRotSpeed)
            {
                snakeAnim.SetBool("attackpropose", true);
                timer = 0;
                Snakemoving = false;
            }
            this.transform.Translate(0, 0, snakeHighSpeed, Space.Self);
        }
        else if (enemydistance > snakeTracking && Snakemoving == true)
        {
           
            // restrain snake in the Snakes Active Range
            float snakeSpeed = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            if (snakeSpeed<0.5 * snakeLowSpeed || Vector3.Distance(snakeActRange.transform.position, this.transform.position) > 0.3 * snakeRangeCollider.size.x)
            {
                Vector3 direction = snakeActRange.transform.position - transform.position;
                direction.y = 0f;
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * snakeRotSpeed);
                }
            }
            this.transform.Translate(0, 0, snakeLowSpeed, Space.Self);
        }

       //stop animation and start escape
        if (timer >= 200 && timer < attackSilence)
        {
            snakeAnim.SetBool("attackpropose", false);
            SnakeEscape = true;
            Snakemoving = true;
        }
        if (timer >= attackSilence)
        {
            SnakeEscape = false;
        }

        timer++;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "target" &&  timer < 100 && timer >10)
        {
            timer = 100;
            Debug.Log("A successful attack");

        }

        if (collision.gameObject.tag == "weapon")
        {
            Vector3 snakepos = this.transform.position;
            Quaternion snakerot = this.transform.rotation;
            GameObject node = Object.Instantiate(snakebody, snakepos, snakerot, null);
            
            Destroy(this.gameObject);
        }
    }
}
