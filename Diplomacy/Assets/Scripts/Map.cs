using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject region;
    private List<Vector3> regionsPos;
    private List<Quaternion> regionsRot;

    // Start is called before the first frame update
    void Start()
    {
        regionsPos = new List<Vector3>();
        regionsPos.Add(new Vector3(-46, -52, 0));
        regionsPos.Add(new Vector3(360, -112, 0));
        regionsPos.Add(new Vector3(-225, -32, 0));
        regionsPos.Add(new Vector3(-142, 80, 0));
        regionsPos.Add(new Vector3(42, 76, 0));
        regionsPos.Add(new Vector3(181, -60, 0));

        var parent = new GameObject("Map");
        for (int i = 0; i < 6; i++)
        {
            var regionClone = Instantiate(region, regionsPos[i], Quaternion.Euler(90, 0, 0));
            regionClone.transform.SetParent(parent.transform);
            var name = $"Region #{i}";
            regionClone.name = name;
            //var regionSettings = GetComponent<Region>();
            var regionSettings = regionClone.GetComponent<Region>();
            if (i == 1 || i == 4)
            {
                regionSettings.hasSupplyCenter = true;

            }
            else regionSettings.hasSupplyCenter = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
