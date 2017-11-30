using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_FlowerCharge : MonoBehaviour
{

    public GameObject player;

    public Rigidbody myRigidbody;

    public float attractiveForce = 2f;
    public float maxVelocity = 10f;
    public float startForce = 5f;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Can't get player");
        }
        myRigidbody.AddForce(Vector3.up * startForce);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        this.transform.LookAt(player.transform);
        Debug.Log("myRigidbody.velocity.magnitude : " + myRigidbody.velocity.magnitude);
        if (myRigidbody.velocity.magnitude < maxVelocity)
        {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance < 5f)
            {
                myRigidbody.AddRelativeForce(Vector3.forward * attractiveForce * distance);
            }
            else
            {
                myRigidbody.AddRelativeForce(Vector3.forward * attractiveForce);
            }

        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }


}
