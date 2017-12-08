using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCP_UIManager : MonoBehaviour
{

    public List<Text> chargeText = new List<Text>();
    public List<Text> plantText = new List<Text>();

    public List<int> chargeValue = new List<int>();
    public List<int> plantValue = new List<int>();


    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 5; i++)
        {
            chargeValue.Add(0);
            plantValue.Add(0);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
    }

    public void AddCharge(int chargeType = 0, int chargeAmount = 1)
    {
        chargeValue[chargeType] = chargeValue[chargeType] + chargeAmount;
        RefreshUI(chargeType);
    }

    public void TransformChargeToPlant(int chargeType = 0)
    {
        chargeValue[chargeType]--;
        plantValue[chargeType]++;
        RefreshUI(chargeType);
    }

    public void RefreshUI(int chargeType = 0)
    {
        chargeText[chargeType].text = "" + chargeValue[chargeType];
        plantText[chargeType].text = "" + plantValue[chargeType];
    }


}
