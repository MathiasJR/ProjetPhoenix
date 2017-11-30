using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_KeyboardPentatonic : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlaySound(2);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaySound(3);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySound(4);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlaySound(5);
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
