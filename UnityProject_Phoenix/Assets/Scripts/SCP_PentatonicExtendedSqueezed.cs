using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_PentatonicExtendedSqueezed : MonoBehaviour
{

    public SCP_Recorder myRecorder;

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
		if (Input.GetKeyDown(KeyCode.A))
        {
            PlaySound(0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaySound(1);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlaySound(2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlaySound(3);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaySound(4);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlaySound(5);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlaySound(6);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaySound(7);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlaySound(8);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySound(9);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlaySound(10);
        }


        // TEST INPUTS FOR DEBUG
        /*foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                Debug.Log("Tested Input : " + vKey);
            }
        }*/
    }

    private void PlaySound(int soundIndex)
    {
        audioSourceList[soundIndex].Play();

        GameObject particleSystemInstance = GameObject.Instantiate(soundParticleSystemPrefab);
        particleSystemInstance.transform.position = this.transform.position;
        particleSystemInstance.GetComponent<ParticleSystemRenderer>().material = materialList[soundIndex];

        myRecorder.RecordInput(soundIndex);

    }


}
