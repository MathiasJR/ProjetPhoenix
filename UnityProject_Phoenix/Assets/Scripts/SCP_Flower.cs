﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_Flower : MonoBehaviour
{

    // 0 : Light Blue, 1 : Light Green, 2 : Yellow, 3 : Orange, 4 : Red
    public int flowerType = 0;

    public GameObject flowerChargePrefab;

    public GameObject spawnPoint;

    public SCP_FlowerMelodyPlayer myMelodyPlayer;

    public float harvestCooldown = 3f;
    private float cooldownTimer = 0;
    public bool canHarvest = true;


    // Use this for initialization
    IEnumerator Start ()
    {
        yield return new WaitForSeconds(0.5f);
        myMelodyPlayer.melodyPlayed = SCP_MelodyManager.melodyList[flowerType];
        myMelodyPlayer.incrementedMelodyTimeList = SCP_MelodyManager.melodyTimingList[flowerType];
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
                //flowerParticleSystem.Stop();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canHarvest == true)
        {
            //flowerParticleSystem.Play();
            canHarvest = false;
            // Security
            if (harvestCooldown < myMelodyPlayer.totalTimeOfTheMelody)
            {
                Debug.LogError("The cooldown time of the flower is shorter than the melody time, this could cause problems is the player harvest while the melody is still playing.");
            }
            myMelodyPlayer.playing = true;

            //Instantiate(flowerChargePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            GameObject flowerChargeInstance = Instantiate(flowerChargePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            flowerChargeInstance.GetComponent<SCP_FlowerCharge>().flowerChargeType = flowerType;
        }
    }

}
