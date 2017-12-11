using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_RotateAround : MonoBehaviour
{

    public Transform centerObject;

    public float movementSpeed = 1f;
    public bool clockwise = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        this.transform.LookAt(centerObject);
        if (clockwise == true)
        {
            this.transform.Translate(Vector3.left * movementSpeed);
        }
        else
        {
            this.transform.Translate(Vector3.right * movementSpeed);
        }
        
    }

}
