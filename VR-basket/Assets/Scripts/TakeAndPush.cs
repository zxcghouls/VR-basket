using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndPush : MonoBehaviour
{
    [SerializeField] private float force;
    GameObject current;
    float timer = 0;
    void Update()
    {
        if( Input.GetMouseButtonDown(0) & current != null)
        {
            timer = 0;
            current.transform.parent = null;
            current.GetComponent<Rigidbody>().isKinematic = false;
            current.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward*force);
            current = null;
        }
        timer += Time.deltaTime;
        Debug.Log(timer);
    }

    private void OnTriggerEnter(Collider other)
    {
        timer += Time.deltaTime;
        if (other.tag == "Ball" & current == null & timer > 1.5f)
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = transform.position;
            other.transform.parent = transform;
            current = other.gameObject;
        }
    }
}
