using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCP_Recorder : MonoBehaviour
{

    public SCP_UIManager myUIManager;

    //public List<int> melodyExemple = new List<int>();

    public SCP_FlowerMelodyPlayer myFlowerMelodyPlayer;

    //public float timeBeforeReset = 2f;

    private int melodyCurrentIndex = 0;
    private bool recordingMelody = false;
    private float melodyTimer = 0;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (recordingMelody == true)
        {
            melodyTimer += Time.deltaTime;
        }
    }

    public void RecordInput(int soundInputIndex)
    {
        //Debug.Log("RecordInput : " + soundInputIndex + " with melodyCurrentIndex : " + melodyCurrentIndex);
        if (myFlowerMelodyPlayer.melodyTest[melodyCurrentIndex].x == soundInputIndex)
        {
            if (melodyCurrentIndex == 0 && melodyTimer == 0)
            {
                StartMelody();
                return;
            }

            float minTime = myFlowerMelodyPlayer.incrementedMelodyTimeList[melodyCurrentIndex] - (myFlowerMelodyPlayer.melodyTest[melodyCurrentIndex].y / 2);
            float maxTime = myFlowerMelodyPlayer.incrementedMelodyTimeList[melodyCurrentIndex] + (myFlowerMelodyPlayer.melodyTest[melodyCurrentIndex].y / 2);
            Debug.Log("melodyTimer : " + melodyTimer + " / minTime : " + minTime + " / maxTime : " + maxTime);
            if (melodyTimer > minTime && melodyTimer < maxTime)
            {
                melodyCurrentIndex++;
                if (melodyCurrentIndex >= myFlowerMelodyPlayer.melodyTest.Count)
                {
                    ValidateMelody();
                }
            }
            else
            {
                FailMelody();
            }
        }
        else
        {
            FailMelody();
        }
    }

    private void StartMelody()
    {
        melodyCurrentIndex = 1;
        melodyTimer = 0;
        recordingMelody = true;
    }

    private void ValidateMelody()
    {
        Debug.Log("ValidateMelody");
        melodyCurrentIndex = 0;
        melodyTimer = 0;
        recordingMelody = false;
        if (myUIManager.chargeValue > 0)
        {
            myUIManager.TransformChargeToPlant();
        }
        else
        {
            Debug.Log("Can't transform plant due to insuficient charge value.");
        }
    }

    private void FailMelody()
    {
        Debug.Log("FailMelody with melodyCurrentIndex : " + melodyCurrentIndex + " and melodyTimer : " + melodyTimer);
        melodyCurrentIndex = 0;
        melodyTimer = 0;
        recordingMelody = false;
    }

}
