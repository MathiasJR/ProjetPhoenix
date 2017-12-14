using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_MelodyManager : MonoBehaviour
{
    public SO_MelodyStorage melodyStorage;

    public static List<List<Vector2>> melodyList;
    public static List<float> bpmList;
    public static List<List<float>> melodyTimingList;


    // Use this for initialization
    void Start()
    {
        melodyList = new List<List<Vector2>>();
        melodyList.Add(melodyStorage.Melody0);
        melodyList.Add(melodyStorage.Melody1);
        melodyList.Add(melodyStorage.Melody2);
        melodyList.Add(melodyStorage.Melody3);
        melodyList.Add(melodyStorage.Melody4);
        melodyList.Add(melodyStorage.Melody5);

        bpmList = new List<float>();
        bpmList.Add(melodyStorage.Bpm0);
        bpmList.Add(melodyStorage.Bpm1);
        bpmList.Add(melodyStorage.Bpm2);
        bpmList.Add(melodyStorage.Bpm3);
        bpmList.Add(melodyStorage.Bpm4);
        bpmList.Add(melodyStorage.Bpm5);

        melodyTimingList = new List<List<float>>();
        float incrementedTimeValue;
        float timeBetweenNotes = 40;
        for (int i = 0; i < melodyList.Count; i++)
        {
            // time between notes is in seconds
            // 120 bpm = 0.5s between notes
            timeBetweenNotes = 60 / bpmList[i];

            incrementedTimeValue = 0;
            List<float> incrementedMelodyTimeList = new List<float>();
            incrementedMelodyTimeList.Add(0);
            for (int j = 0; j < melodyList[i].Count; j++)
            {
                incrementedTimeValue += melodyList[i][j].y * timeBetweenNotes;
                incrementedMelodyTimeList.Add(incrementedTimeValue);
            }
            melodyTimingList.Add(incrementedMelodyTimeList);
            Debug.Log("Total time of the melody : " + incrementedTimeValue);
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
