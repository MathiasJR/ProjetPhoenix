using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_PlayerMovement : MonoBehaviour
{

    private NavMeshAgent playerNavMeshAgent;

    public GameObject mouseInGameObject;

    private Vector3 targetPosition = new Vector3();
    private Vector3 mousePosition = new Vector3();
    private RaycastHit myRaycastHit;
    private Ray myRay;

    // Use this for initialization
    void Start()
    {

        playerNavMeshAgent = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        if (playerNavMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent for the player not found");
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        



    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(myRay, out myRaycastHit, 99f))
            {
                Debug.DrawRay(myRay.origin, myRaycastHit.point);
                //Debug.Log("Hit on position : " + myRaycastHit.point);
                mousePosition = myRaycastHit.point;
                mouseInGameObject.transform.position = mousePosition;
                if (myRaycastHit.transform.tag == "Terrain")
                {
                    targetPosition = myRaycastHit.point;
                    //Debug.Log("New Target for playerNavMeshAgent " + targetPosition);
                    playerNavMeshAgent.SetDestination(targetPosition);
                }
            }


        }


    }

}
