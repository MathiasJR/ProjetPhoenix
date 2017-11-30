using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_Flower : MonoBehaviour
{

    public GameObject flowerChargePrefab;

    public ParticleSystem flowerParticleSystem;
    public GameObject spawnPoint;

    public float harvestCooldown = 3f;
    private float cooldownTimer = 0;
    public bool canHarvest = true;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (canHarvest == false)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= harvestCooldown)
            {
                canHarvest = true;
                cooldownTimer = 0;
                flowerParticleSystem.Stop();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canHarvest == true)
        {
            flowerParticleSystem.Play();
            canHarvest = false;
            Instantiate(flowerChargePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

}
