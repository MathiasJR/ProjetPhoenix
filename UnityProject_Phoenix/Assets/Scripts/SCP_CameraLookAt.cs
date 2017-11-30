using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_CameraLookAt : MonoBehaviour
{

    public GameObject playerGameObject;


	// Use this for initialization
	void Start ()
    {
        Camera.main.transform.LookAt(playerGameObject.transform);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
