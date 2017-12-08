using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_MultiRecorder : MonoBehaviour
{
    public SCP_UIManager myUIManager;

    public Animator validationAnimator;

    public bool recording = false;

    public float timingToleranceDivisor = 3f; // duration of the note divised by this variable (higher value means more difficult)

    private List<List<Vector2>> melodiesPossiblyPlaying = new List<List<Vector2>>();
    private List<List<float>> timingforMelodiesPossible = new List<List<float>>();

    private int currentNoteIndex = 0;
    private float melodyTimer = 0;

    private float maxTimeBeforeReset = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (recording == true)
        {
            melodyTimer += Time.deltaTime;
            if(melodyTimer > maxTimeBeforeReset)
            {
                FailMelody();
            }
        }
    }

    public void RecordInput(int inputIndex = 0)
    {
        if (recording == false)
        {
            StartMelodyRecord(inputIndex);
        }
        else
        {
            RecordNextInput(inputIndex);
        }
    }

    private void StartMelodyRecord(int inputIndex = 0)
    {
        melodiesPossiblyPlaying = new List<List<Vector2>>();
        timingforMelodiesPossible = new List<List<float>>();
        // Add possible melody lists into the dynamic list of possible melodies that the player could be trying to play
        for (int i = 0; i < SCP_MelodyManager.melodyList.Count; i++)
        {
            //Debug.Log("i : " + i + " / inputIndex : " + inputIndex + " / SCP_MelodyManager.melodyList[i][0].x : " + SCP_MelodyManager.melodyList[i][0].x);
            if (SCP_MelodyManager.melodyList[i][0].x == inputIndex)
            {
                melodiesPossiblyPlaying.Add(SCP_MelodyManager.melodyList[i]);
                timingforMelodiesPossible.Add(SCP_MelodyManager.melodyTimingList[i]);
                recording = true;
                currentNoteIndex = 1;
                CalculateTimeBeforeReset();
                Debug.Log("StartMelodyRecord with input : " + inputIndex);
            }
        }
    }

    private void RecordNextInput(int inputIndex = 0)
    {
        // Check and remove lists based on the note value from all the possible melodies the player could be trying to play
        for (int i = melodiesPossiblyPlaying.Count - 1; i >= 0; i--)
        {
            //Debug.Log("i : " + i);
            if (melodiesPossiblyPlaying[i][currentNoteIndex].x != inputIndex)
            {
                melodiesPossiblyPlaying.RemoveAt(i);
                timingforMelodiesPossible.RemoveAt(i);
            }
        }

        // Check and remove lists based on the timing of the note played
        for (int i = melodiesPossiblyPlaying.Count - 1; i >= 0; i--)
        {
            /*Debug.Log("i : " + i);
            for (int j = 0; j < melodiesPossiblyPlaying[i].Count; j++)
            {
                Debug.Log("melodiesPossiblyPlaying[i][j] : " + melodiesPossiblyPlaying[i][j]);
            }*/
            //Debug.Log("SCP_MelodyManager.melodyTimingList[i][currentNoteIndex] : " + SCP_MelodyManager.melodyTimingList[i][currentNoteIndex]);
            //Debug.Log("currentNoteIndex : " + currentNoteIndex);
            //Debug.Log("SCP_MelodyManager.melodyList[i][currentNoteIndex] : " + SCP_MelodyManager.melodyList[i][currentNoteIndex]);
            float minTime = timingforMelodiesPossible[i][currentNoteIndex] - (melodiesPossiblyPlaying[i][currentNoteIndex].y / timingToleranceDivisor);
            float maxTime = timingforMelodiesPossible[i][currentNoteIndex] + (melodiesPossiblyPlaying[i][currentNoteIndex].y / timingToleranceDivisor);
            //Debug.Log("melodyTimer : " + melodyTimer + " / minTime : " + minTime + " / maxTime : " + maxTime);
            if (melodyTimer < minTime || melodyTimer > maxTime)
            {
                melodiesPossiblyPlaying.RemoveAt(i);
                timingforMelodiesPossible.RemoveAt(i);
            }
        }

        // Check if there is still a melody playing
        //Debug.Log("melodiesPossiblyPlaying.Count : " + melodiesPossiblyPlaying.Count);
        if (melodiesPossiblyPlaying.Count <= 0)
        {
            FailMelody();
        }
        else if (melodiesPossiblyPlaying.Count > 1)
        {
            ContinueMelody();
        }
        else
        {
            //Debug.Log("RHELLO");
            if (currentNoteIndex + 1 >= melodiesPossiblyPlaying[0].Count)
            {
                ValidateMelody(SCP_MelodyManager.melodyList.IndexOf(melodiesPossiblyPlaying[0]));
            }
            else
            {
                ContinueMelody();
            }
        }


    }

    private void ContinueMelody()
    {
        currentNoteIndex++;
        Debug.Log("ContinueMelody with currentNoteIndex : " + currentNoteIndex);
        CalculateTimeBeforeReset();
    }

    private void ValidateMelody(int melodyIndex)
    {
        Debug.Log("ValidateMelody with melodyIndex : " + melodyIndex);
        recording = false;
        melodyTimer = 0;
        currentNoteIndex = 0;
        if( melodyIndex == -1)
        {
            Debug.LogError("Can't find melody in manager");
            return;
        }
        if (myUIManager.chargeValue[melodyIndex] > 0)
        {
            myUIManager.TransformChargeToPlant(melodyIndex);
        }
        else
        {
            Debug.Log("Can't transform plant due to insuficient charge value.");
        }

        validationAnimator.SetBool("blink", true);
        Invoke("ResetValidationAnimator", 0.2f);
    }

    private void ResetValidationAnimator()
    {
        validationAnimator.SetBool("blink", false);
    }

    private void FailMelody()
    {
        Debug.Log("FailMelody");
        recording = false;
        melodyTimer = 0;
        currentNoteIndex = 0;
    }

    private void CalculateTimeBeforeReset()
    {
        float maxTiming = 0;
        for (int i = 0; i < timingforMelodiesPossible.Count; i++)
        {
            if (timingforMelodiesPossible[i][currentNoteIndex] + (melodiesPossiblyPlaying[i][currentNoteIndex].y / timingToleranceDivisor) > maxTiming)
            {
                maxTiming = timingforMelodiesPossible[i][currentNoteIndex] + (melodiesPossiblyPlaying[i][currentNoteIndex].y / timingToleranceDivisor);
            }
        }
        //Debug.Log("New maxTimeBeforeReset : " + maxTiming);
        maxTimeBeforeReset = maxTiming;
    }

}
