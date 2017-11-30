using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_Autodestruction : MonoBehaviour
{

    public float timeBeforeDestruction = 3f;
    private float timer = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBeforeDestruction)
        {
            Destroy(this.gameObject);
        }
    }
}

