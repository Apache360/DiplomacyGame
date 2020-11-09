using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public int id;
    public new string name;
    public bool hasSupplyCenter;
    public Vector3 regionPos;
    public Quaternion regionRot;
    public Country country;

    /*public Region(int id, string _name, Country country, bool hasSupplyCenter, Vector3 regionPos, Quaternion regionRot)
    {
        this.id = id;
        this.name = _name;
        this.country = country;
        this.hasSupplyCenter = hasSupplyCenter;
        this.regionPos = regionPos;
        this.regionRot = regionRot;
    }*/

    public Region()
    {
    }

    /*public Vector3 getRegionPos()
    {
        return this.regionPos;
    }

    public Quaternion getRegionRot()
    {
        return this.regionRot;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSupplyCenter)
        {
            
        }
    }
}
