using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_Keyboard : MonoBehaviour
{

    public GameObject soundParticleSystemPrefab;

    public List<AudioSource> audioSourceList = new List<AudioSource>();

    public List<Material> materialList = new List<Material>();


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaySound(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlaySound(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaySound(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlaySound(3);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlaySound(4);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaySound(5);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlaySound(6);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySound(7);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlaySound(8);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlaySound(9);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlaySound(10);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlaySound(11);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlaySound(12);
        }




    }

    private void PlaySound(int soundIndex)
    {
        audioSourceList[soundIndex].Play();

        GameObject particleSystemInstance = GameObject.Instantiate(soundParticleSystemPrefab);
        particleSystemInstance.transform.position = this.transform.position;
        soundParticleSystemPrefab.GetComponent<ParticleSystemRenderer>().material = materialList[soundIndex];
        //particleSystemInstance.GetComponent<ParticleSystem>().Play();

    }


}
