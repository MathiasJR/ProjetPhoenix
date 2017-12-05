using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_FlowerMelodyPlayer : MonoBehaviour
{

    public GameObject soundParticleSystemPrefab;

    public List<AudioSource> audioSourceList = new List<AudioSource>();

    public List<Material> materialList = new List<Material>();

    public List<int> melodyExemple = new List<int>();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void PlaySound(int soundIndex)
    {
        audioSourceList[soundIndex].Play();

        GameObject particleSystemInstance = GameObject.Instantiate(soundParticleSystemPrefab);
        particleSystemInstance.transform.position = this.transform.position;
        particleSystemInstance.GetComponent<ParticleSystemRenderer>().material = materialList[soundIndex];


    }

}
