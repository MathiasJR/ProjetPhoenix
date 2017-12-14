using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCP_FlowerUI : MonoBehaviour
{

    public Text chargeText;
    public List<Text> plantTextList;

    public int chargeValue = 0;
    public List<int> plantValueList;


    // Use this for initialization
    void Start()
    {
        plantValueList = new List<int>();
        for (int i = 0; i < plantTextList.Count; i++)
        {
            plantValueList.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCharge(int chargeAmount = 1)
    {
        chargeValue += chargeAmount;
        RefreshUI();
    }

    public void TransformChargeToPlant(int plantQuality = 0)
    {
        chargeValue--;
        plantValueList[plantQuality]++;
        RefreshUI(plantQuality);
    }

    public void RefreshUI(int plantQuality = 0)
    {
        chargeText.text = "" + chargeValue;
        plantTextList[plantQuality].text = "" + plantValueList[plantQuality];
    }

}
