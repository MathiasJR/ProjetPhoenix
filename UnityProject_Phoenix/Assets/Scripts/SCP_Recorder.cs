using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCP_Recorder : MonoBehaviour
{

    public SCP_UIManager myUIManager;

    public List<int> melodyExemple = new List<int>();

    //public float timeBeforeReset = 2f;

    private int melodyCurrentIndex = 0;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
    }

    public void RecordInput(int soundInputIndex)
    {
        Debug.Log("RecordInput : " + soundInputIndex + " with melodyCurrentIndex : " + melodyCurrentIndex);
        if (melodyExemple[melodyCurrentIndex] == soundInputIndex)
        {
            melodyCurrentIndex++;
            if (melodyCurrentIndex >= melodyExemple.Count)
            {
                ValidateMelody();
                melodyCurrentIndex = 0;
            }
        }
        else
        {
            melodyCurrentIndex = 0;
        }
    }

    private void ValidateMelody()
    {
        if (myUIManager.chargeValue > 0)
        {
            myUIManager.TransformChargeToPlant();
        }
        else
        {
            Debug.Log("Can't validate melody due to insuficient charge value.");
        }
    }

}
