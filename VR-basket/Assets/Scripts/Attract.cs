using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour
{
    GameObject[] balls;
    public float attractForce;
    void Start()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            float angle = 360;
            GameObject attractedBall = balls[0];
            foreach ( GameObject ball in balls)
            {
                Vector3 targetDir = ball.transform.position - transform.position;
                if (Vector3.Angle(targetDir, transform.forward) < angle)
                {
                    angle = Vector3.Angle(targetDir, transform.forward);
                    attractedBall = ball;
                }
            }
            if (Vector3.Angle(attractedBall.transform.position - transform.position, transform.forward) < 20)
            {
                attractedBall.GetComponent<Rigidbody>().AddForce((transform.position - attractedBall.transform.position).normalized * attractForce, ForceMode.Impulse);
            }
        }        
    }
}
