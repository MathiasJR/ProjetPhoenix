using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_CameraRig : MonoBehaviour
{

    public GameObject player;

    public float rotationSpeed = 200f;

    private float horizontalRotation = 0;
    private bool alreadyStarted = false;
    private float startHorizontalRotation = 0;
    private float rotationAmount = 0;
    private float startMousePosition = 0;

    /*public float lerpSpeed = 2f;

    private Vector3 wantedPosition = new Vector3();*/

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (alreadyStarted == false)
            {
                startHorizontalRotation = Mathf.Abs(this.transform.rotation.eulerAngles.y);
                //Debug.Log("New startHorizontalRotation : " + startHorizontalRotation);
                startMousePosition = Mathf.Abs(Input.mousePosition.x);
                //Debug.Log("New startMousePosition : " + startMousePosition);
                alreadyStarted = true;
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (alreadyStarted == true)
            {
                rotationAmount = Mathf.Abs(Input.mousePosition.x) - startMousePosition;
                rotationAmount /= Screen.width;
                rotationAmount *= rotationSpeed;
                rotationAmount = rotationAmount % 360;
                horizontalRotation = rotationAmount + startHorizontalRotation;
                this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, horizontalRotation, this.transform.rotation.z);
            }

        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            alreadyStarted = false;
        }
    }

    private void FixedUpdate()
    {
        /*wantedPosition = Vector3.Lerp(player.transform.position, this.transform.position, Time.deltaTime * lerpSpeed);

        this.transform.position = wantedPosition;*/

        this.transform.position = player.transform.position;

        /*if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            startHorizontalRotation = this.transform.rotation.eulerAngles.y;
            Debug.Log("New startHorizontalRotation : " + startHorizontalRotation);
            startMousePosition = Input.mousePosition.x / Screen.width;
            Debug.Log("New startMousePosition : " + startMousePosition);
        }

        if (Input.GetKey(KeyCode.Mouse2))
        {
            //Debug.Log("Input.mousePosition.x : " + Input.mousePosition.x);
            rotationAmount = Input.mousePosition.x  / Screen.width;
            rotationAmount += startMousePosition;
            //Debug.Log("rotationAmount : " + rotationAmount);
            horizontalRotation = startHorizontalRotation + rotationAmount;
            //Debug.Log("horizontalRotation : " + horizontalRotation);
            horizontalRotation = horizontalRotation * 100;
           // Debug.Log("horizontalRotation after 360 : " + horizontalRotation);
            horizontalRotation = horizontalRotation % 360;
            //Debug.Log("horizontalRotation after % : " + horizontalRotation);

            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, horizontalRotation, this.transform.rotation.z);
        }*/


        

    }


}
