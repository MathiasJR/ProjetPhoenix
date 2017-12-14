using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_MultiRecorder : MonoBehaviour
{
    public SCP_UIManager myUIManager;

    public Animator validationAnimator;

    public bool recording = false;

    public float timingTolerance = 2.5f; // With a 120pbm, 60/120bpm = 0.5s then divided by timingTolerance : 0.2s

    private List<List<Vector2>> melodiesPossiblyPlaying = new List<List<Vector2>>();
    private List<float> bpmForMelodiesPossible = new List<float>();
    private List<List<float>> timingForMelodiesPossible = new List<List<float>>();
    private List<float> tempoAdaptationForMelodiesPossible = new List<float>();
    private List<float> playerTimingForMelodiesPossible = new List<float>();

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
        bpmForMelodiesPossible = new List<float>();
        timingForMelodiesPossible = new List<List<float>>();
        tempoAdaptationForMelodiesPossible = new List<float>();
        playerTimingForMelodiesPossible = new List<float>();
        // Add possible melody lists into the dynamic list of possible melodies that the player could be trying to play
        for (int i = 0; i < SCP_MelodyManager.melodyList.Count; i++)
        {
            if (SCP_MelodyManager.melodyList[i][0].x == inputIndex)
            {
                melodiesPossiblyPlaying.Add(SCP_MelodyManager.melodyList[i]);
                bpmForMelodiesPossible.Add(SCP_MelodyManager.bpmList[i]);
                timingForMelodiesPossible.Add(SCP_MelodyManager.melodyTimingList[i]);
                tempoAdaptationForMelodiesPossible.Add(0);
                playerTimingForMelodiesPossible.Add(0);
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
            if (melodiesPossiblyPlaying[i][currentNoteIndex].x != inputIndex)
            {
                RemoveMelodieFromPossibleLists(i);
            }
        }

        // Check and remove lists based on the timing of the note played
        for (int i = melodiesPossiblyPlaying.Count - 1; i >= 0; i--)
        {
            float minTime = timingForMelodiesPossible[i][currentNoteIndex] + tempoAdaptationForMelodiesPossible[i] - (60 / bpmForMelodiesPossible[i] / timingTolerance);
            float maxTime = timingForMelodiesPossible[i][currentNoteIndex] + tempoAdaptationForMelodiesPossible[i] + (60 / bpmForMelodiesPossible[i] / timingTolerance);
            Debug.Log("melodyTimer : " + melodyTimer +
                " / perfect timing : " + timingForMelodiesPossible[i][currentNoteIndex] +
                " / perfect timing with adaptation : " + (timingForMelodiesPossible[i][currentNoteIndex] + tempoAdaptationForMelodiesPossible[i]) + 
                " / minTime : " + minTime + " / maxTime : " + maxTime);
            if (melodyTimer < minTime || melodyTimer > maxTime)
            {
                RemoveMelodieFromPossibleLists(i);
            }
            else // Save the timing of the note played and update the tempo expected of the player
            {
                playerTimingForMelodiesPossible[i] += Mathf.Abs(melodyTimer - timingForMelodiesPossible[i][currentNoteIndex] + tempoAdaptationForMelodiesPossible[i]);
                tempoAdaptationForMelodiesPossible[i] += melodyTimer - timingForMelodiesPossible[i][currentNoteIndex];
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
        if (melodyIndex == -1)
        {
            Debug.LogError("Can't find melody in manager");
            return;
        }

        // Determine the quality of the melodie that the player validates
        float score = 0;
        Debug.Log("Final tempo adaptation : " + tempoAdaptationForMelodiesPossible[0]);
        if (Mathf.Abs(tempoAdaptationForMelodiesPossible[0]) < (60 / bpmForMelodiesPossible[0] / timingTolerance))
        {
            Debug.Log("Perfect Tempo !");
            score += 3;
        }
        else if (Mathf.Abs(tempoAdaptationForMelodiesPossible[0]) < (60 / bpmForMelodiesPossible[0] / (timingTolerance / 2)))
        {
            Debug.Log("Good Tempo");
            score += 2;
        }
        else
        {
            Debug.Log("Meh Tempo");
            score += 1;
        }
        Debug.Log("Final timing score : " + playerTimingForMelodiesPossible[0]);
        if (playerTimingForMelodiesPossible[0] < ((60 / bpmForMelodiesPossible[0] / timingTolerance) * melodiesPossiblyPlaying[0].Count) / 3)
        {
            Debug.Log("Perfect Timing !");
            score += 3;
        }
        else if (playerTimingForMelodiesPossible[0] < ((60 / bpmForMelodiesPossible[0] / timingTolerance) * melodiesPossiblyPlaying[0].Count) / 2)
        {
            Debug.Log("Good Timing");
            score += 2;
        }
        else
        {
            Debug.Log("Meh Timing");
            score += 1;
        }
        int plantQuality = 0;
        if (score > 5)
        {
            plantQuality = 0;
        }
        else if (score > 3)
        {
            plantQuality = 1;
        }
        else
        {
            plantQuality = 2;
        }

        if (myUIManager.flowerUI[melodyIndex].chargeValue > 0)
        {
            myUIManager.TransformChargeToPlant(melodyIndex, plantQuality);
        }
        else
        {
            Debug.Log("Can't transform plant due to insuficient charge value.");
        }

        validationAnimator.SetBool("blink", true);
        Invoke("ResetValidationAnimator", 0.2f);
    }

    private void FailMelody()
    {
        Debug.Log("FailMelody");
        recording = false;
        melodyTimer = 0;
        currentNoteIndex = 0;
    }

    private void RemoveMelodieFromPossibleLists(int index = 0)
    {
        melodiesPossiblyPlaying.RemoveAt(index);
        bpmForMelodiesPossible.RemoveAt(index);
        timingForMelodiesPossible.RemoveAt(index);
        tempoAdaptationForMelodiesPossible.RemoveAt(index);
        playerTimingForMelodiesPossible.RemoveAt(index);
    }

    private void CalculateTimeBeforeReset()
    {
        float maxTiming = 0;
        for (int i = 0; i < timingForMelodiesPossible.Count; i++)
        {
            if (timingForMelodiesPossible[i][currentNoteIndex] + (60 / bpmForMelodiesPossible[i] / timingTolerance) > maxTiming)
            {
                maxTiming = timingForMelodiesPossible[i][currentNoteIndex] + (60 / bpmForMelodiesPossible[i] / timingTolerance);
            }
        }
        Debug.Log("New maxTimeBeforeReset : " + maxTiming);
        maxTimeBeforeReset = maxTiming;
    }

    private void ResetValidationAnimator()
    {
        validationAnimator.SetBool("blink", false);
    }

    private void ChangeTempoOfTimingList(int listIndexToChange = 0, float tempoChange = 0)
    {
        for (int i = 0; i< timingForMelodiesPossible[listIndexToChange].Count; i++)
        {

        }
    }

}
