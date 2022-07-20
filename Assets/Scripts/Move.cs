using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] float thrust = 1000;
    [SerializeField] float rotatePower = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
    }

    void ProcessThrust()
    {
        ProcessBoost();
        ProcessRotate();
        
    }

    void ProcessBoost()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*thrust*Time.deltaTime);
        }
    }

    void ProcessRotate()
    {
        Vector3 rotateApply = Vector3.forward*rotatePower*Time.deltaTime;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.freezeRotation = true;
            transform.Rotate(rotateApply);
            rb.freezeRotation = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.freezeRotation = true;
            transform.Rotate(-rotateApply);
            rb.freezeRotation = false;
        }
    }
}
