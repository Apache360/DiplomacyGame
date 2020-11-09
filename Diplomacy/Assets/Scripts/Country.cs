using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    public string countryName;
    public Color countryDefaultColor;
    public List<Region> regions=new List<Region>();

    public Country(string _name, Color countryDefaultColor)
    {
        this.countryName = _name;
        this.countryDefaultColor = countryDefaultColor;
    }

    public List<Region> getRegions()
    {
        MapManager manager = new MapManager();
        List<GameObject> gameObjects = manager.getRegions();
        for (int i = 0; i < gameObjects.Count; i++)
        {
            regions.Add(gameObjects[i].GetComponent<Region>());
        }
        return regions;
    }

    public int getRegionsCount(Country country)
    {
        int regionsCount = 0;
        regions = getRegions();
        for (int i = 0; i < regions.Count; i++)
        {
            if (regions[i].country==country)
            {
                regionsCount++;
            }
        }
        return regionsCount;
    }

    public int getRegionsSupplyCount(Country country)
    {
        int regionsSupplyCount = 0;
        regions = getRegions();
        for (int i = 0; i < regions.Count; i++)
        {
            if (regions[i].country == country&&regions[i].hasSupplyCenter)
            {
                regionsSupplyCount++;
            }
        }
        return regionsSupplyCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
