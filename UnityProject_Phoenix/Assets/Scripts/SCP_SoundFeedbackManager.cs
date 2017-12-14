using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_SoundFeedbackManager : MonoBehaviour
{

    public Animator myAnimator;

    public float timeBeforeBoolReset = 0.1f;
    private float timer = 0;
    private bool playing = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playing == true)
        {
            timer += Time.deltaTime;
            if (timer > timeBeforeBoolReset)
            {
                StopAnimation();
                timer = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void PlayAnimation()
    {
        myAnimator.SetBool("play", true);
        playing = true;
        timer = 0;
    }

    public void StopAnimation()
    {
        myAnimator.SetBool("play", false);
    }

}

