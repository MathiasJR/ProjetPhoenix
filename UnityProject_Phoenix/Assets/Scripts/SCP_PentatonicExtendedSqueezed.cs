using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_PentatonicExtendedSqueezed : MonoBehaviour
{

    public SCP_Recorder myRecorder;
    public SCP_MultiRecorder multiRecorder;

    public SCP_SoundFeedbackManager soundFeedbackManager;

    public GameObject soundParticleSystemPrefab;

    public List<AudioSource> audioSourceList = new List<AudioSource>();

    public List<Material> materialList = new List<Material>();

    public bool inputPressed = false;
    public float timeBeforeInputReset = 2f;
    private float inputTimer = 0;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        inputTimer += Time.deltaTime;

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

        if (inputPressed == true && inputTimer > timeBeforeInputReset)
        {
            inputPressed = false;
            inputTimer = 0;
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
        ResetInputTimer();

        audioSourceList[soundIndex].Play();

        /*GameObject particleSystemInstance = GameObject.Instantiate(soundParticleSystemPrefab);
        particleSystemInstance.transform.position = this.transform.position;
        particleSystemInstance.GetComponent<ParticleSystemRenderer>().material = materialList[soundIndex];*/

        soundFeedbackManager.PlayAnimation();

        //myRecorder.RecordInput(soundIndex);
        multiRecorder.RecordInput(soundIndex);
    }

    private void ResetInputTimer()
    {
        inputPressed = true;
        inputTimer = 0;
    }

}
