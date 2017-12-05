using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_Flower : MonoBehaviour
{

    public GameObject flowerChargePrefab;

    public ParticleSystem flowerParticleSystem;
    public GameObject spawnPoint;

    public SCP_FlowerMelodyPlayer myMelodyPlayer;

    public float harvestCooldown = 3f;
    private float cooldownTimer = 0;
    public bool canHarvest = true;

    private float timeBetweenNotes = 0.1f;
    private int noteIndex = 0;

    // Use this for initialization
    void Start ()
    {
        timeBetweenNotes = harvestCooldown / myMelodyPlayer.melodyExemple.Count;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (canHarvest == false)
        {
            cooldownTimer += Time.deltaTime;

            // MUSIC
            for (int i = 0; i < myMelodyPlayer.melodyExemple.Count; i++)
            {
                if (cooldownTimer > (timeBetweenNotes * (noteIndex + 1)))
                {
                    myMelodyPlayer.PlaySound(myMelodyPlayer.melodyExemple[noteIndex]);

                    noteIndex++;
                    return;
                }
            }

            // RESET
            if (cooldownTimer >= harvestCooldown)
            {
                noteIndex = 0;
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
            Instantiate(flowerChargePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

}
