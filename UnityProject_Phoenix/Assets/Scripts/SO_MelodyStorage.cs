using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SO_MelodyStorage : ScriptableObject
{

    [Space(10)]
    [Header("Melodies")]

    [Space(10)]
    [SerializeField]
    [Tooltip("BPM of the melody n°0")]
    private float _bpm0;
    public float Bpm0
    {
        get { return _bpm0; }
    }
    [SerializeField]
    [Tooltip("Light Blue flower's melody")]
    private List<Vector2> _melody0;
    public List<Vector2> Melody0
    {
        get { return _melody0; }
    }

    [Space(10)]
    [SerializeField]
    [Tooltip("BPM of the melody n°1")]
    private float _bpm1;
    public float Bpm1
    {
        get { return _bpm1; }
    }
    [SerializeField]
    [Tooltip("Light Green flower's melody")]
    private List<Vector2> _melody1;
    public List<Vector2> Melody1
    {
        get { return _melody1; }
    }

    [Space(10)]
    [SerializeField]
    [Tooltip("BPM of the melody n°2")]
    private float _bpm2;
    public float Bpm2
    {
        get { return _bpm2; }
    }
    [SerializeField]
    [Tooltip("Yellow flower's melody")]
    private List<Vector2> _melody2;
    public List<Vector2> Melody2
    {
        get { return _melody2; }
    }

    [Space(10)]
    [SerializeField]
    [Tooltip("BPM of the melody n°3")]
    private float _bpm3;
    public float Bpm3
    {
        get { return _bpm3; }
    }
    [SerializeField]
    [Tooltip("Orange flower's melody")]
    private List<Vector2> _melody3;
    public List<Vector2> Melody3
    {
        get { return _melody3; }
    }

    [Space(10)]
    [SerializeField]
    [Tooltip("BPM of the melody n°4")]
    private float _bpm4;
    public float Bpm4
    {
        get { return _bpm4; }
    }
    [SerializeField]
    [Tooltip("Red flower's melody")]
    private List<Vector2> _melody4;
    public List<Vector2> Melody4
    {
        get { return _melody4; }
    }


}
