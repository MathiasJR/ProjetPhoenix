using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCP_UIManager : MonoBehaviour
{

    public Text chargeText;
    public Text plantText;

    public int chargeValue = 0;
    public int plantValue = 0;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
    }

    public void AddCharge(int chargeAmount = 1)
    {
        chargeValue = chargeValue + chargeAmount;
        RefreshUI();
    }

    public void TransformChargeToPlant()
    {
        chargeValue--;
        plantValue++;
        RefreshUI();
    }

    public void RefreshUI()
    {
        chargeText.text = "Charge : " + chargeValue;
        plantText.text = "Plant : " + plantValue;
    }


}
