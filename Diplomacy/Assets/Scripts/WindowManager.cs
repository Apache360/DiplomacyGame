using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
    public GameObject rect;
    Text country;
    Text info;

    void Start()
    {
        
    }

    public void openAdditionalWindow(GameObject objClicked)
    {
        rect = GameObject.Find("Window");
        rect.SetActive(true);
        country = GameObject.Find("Country").GetComponent<Text>();
        info = GameObject.Find("Info").GetComponent<Text>();
        Region region = objClicked.GetComponent<Region>();
        country.text = 
            $"{region.country.name}";
        info.text = $"{region.name} (#{region.id})\n";
        if (region.hasSupplyCenter) info.text += "Supple center\n";
        info.text += $"Total regions: {region.country.getRegionsCount(region.country)}\n" +
            $"Total supply regions: {region.country.getRegionsSupplyCount(region.country)}\n";

    }

    public void closeAdditionalWindow()
    {
        rect.SetActive(false);
    }
}
