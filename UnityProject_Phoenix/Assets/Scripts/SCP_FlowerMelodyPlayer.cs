using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_FlowerMelodyPlayer : MonoBehaviour
{

    public GameObject soundParticleSystemPrefab;

    public List<AudioSource> audioSourceList = new List<AudioSource>();

    public List<Material> materialList = new List<Material>();

    public bool playing = false;

    public float bpm = 120f;
    private float timeBetweenNotes = 0;
    public float totalTimeOfTheMelody = 0;
    public List<Vector2> melodyTest = new List<Vector2>();

    private float melodyTimer = 0;
    private int noteIndex = 0;
    private List<float> incrementedMelodyTimeList = new List<float>();
    private float incrementedTimeValue = 0;

    // Use this for initialization
    void Start()
    {
        // time between notes is in seconds
        // 120 bpm = 0.5s between notes
        timeBetweenNotes = 60 / bpm;

        incrementedTimeValue = 0;
        incrementedMelodyTimeList = new List<float>();
        incrementedMelodyTimeList.Add(0);
        for (int i = 0; i < melodyTest.Count; i++)
        {
            incrementedTimeValue += melodyTest[i].y * timeBetweenNotes;
            incrementedMelodyTimeList.Add(incrementedTimeValue);
        }
        totalTimeOfTheMelody = incrementedTimeValue;
        Debug.Log("totalTimeOfTheMelody : " + totalTimeOfTheMelody);
    }

    // Update is called once per frame
    void Update()
    {
        if (playing == true)
        {
            melodyTimer += Time.deltaTime;

            for (int i = 0; i < melodyTest.Count; i++)
            {
               // Debug.Log("noteIndex : " + noteIndex);
                if (melodyTimer > incrementedMelodyTimeList[noteIndex])
                {
                    int note = Mathf.CeilToInt(melodyTest[noteIndex].x);
                    Debug.Log("melodyTimer : " + melodyTimer);
                    PlaySound(note);

                    noteIndex++;

                    // RESET
                    if( noteIndex == melodyTest.Count)
                    {
                        noteIndex = 0;
                        playing = false;
                        melodyTimer = 0;
                    }
                    return;
                }
            }
        }

    }


    public void PlaySound(int soundIndex)
    {
        Debug.Log("PlaySound with soundIndex : " + soundIndex);
        audioSourceList[soundIndex].Play();

        GameObject particleSystemInstance = GameObject.Instantiate(soundParticleSystemPrefab);
        particleSystemInstance.transform.position = this.transform.position;
        particleSystemInstance.GetComponent<ParticleSystemRenderer>().material = materialList[soundIndex];

    }

}
