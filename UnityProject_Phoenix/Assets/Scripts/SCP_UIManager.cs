using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCP_UIManager : MonoBehaviour
{

    public List<SCP_FlowerUI> flowerUI;


    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
    }

    public void AddCharge(int chargeType = 0, int chargeAmount = 1)
    {
        flowerUI[chargeType].AddCharge(chargeAmount);
    }

    public void TransformChargeToPlant(int chargeType = 0, int plantQuality = 0)
    {
        flowerUI[chargeType].TransformChargeToPlant(plantQuality);
    }


}
