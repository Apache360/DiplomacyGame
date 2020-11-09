using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    Color red = Color.red;
    Color green = Color.green;
    Color yellow = Color.yellow;
    Color magenta = Color.magenta;
    Color cyan = Color.cyan;
    Color white = Color.white;
        
    static Color colorDefaultNeutral = new Color(0.5764705882f, 0.5686274510f, 0.5411764706f);
    static Color colorDefaultRus = new Color(0.4f, 0.4352941176f, 0.3137254902f);
    static Color colorDefaultTur = new Color(0.5607843137f, 0.7137254902f, 0.5372549020f);
    static Color colorDefaultEng = new Color(0.6352941176f, 0.2117647059f, 0.1725490196f);
    static Color colorDefaultFra = new Color(0.2627450980f, 0.3019607843f, 0.6509803922f);
    static Color colorDefaultGer = new Color(0.5019607843f, 0.4705882353f, 0.4627450980f);
    static Color colorDefaultAus = new Color(0.9372549020f, 0.9019607843f, 0.8352941176f);

    static Color colorDefaultIta = new Color(0.4745098039f, 0.5098039216f, 0.2862745098f);
    static Color colorDefaultSpa = new Color(1, 0.8470588235f, 0.3176470588f);

    public GameObject prefab;
    public Texture matSupplyReg;
    public Texture matDefaultReg;
    public List<GameObject> regions;
    public List<Country> countries;
    bool hasSupplyCenter;
    const int regionsCount=56;
    
    public List<List<int>> matrix;
    
    void Start()
    {        
        //
        //setting countries
        //
        countries = new List<Country>();
        countries.Add(new Country("Neutral", colorDefaultNeutral));//0
        countries.Add(new Country("Austria", colorDefaultAus));//1
        countries.Add(new Country("England", colorDefaultEng));//2
        countries.Add(new Country("France", colorDefaultFra));//3
        countries.Add(new Country("Germany", colorDefaultGer));//4
        countries.Add(new Country("Italy", colorDefaultIta));//5
        countries.Add(new Country("Russia", colorDefaultRus));//6
        countries.Add(new Country("Spain", colorDefaultSpa));//7
        countries.Add(new Country("Turkey", colorDefaultTur));//8

        //
        //adding GameObjects with general settings from prefab
        //
        regions = new List<GameObject>();
        Region region = new Region();
        var parentMap = new GameObject("Map");
        for (int i = 0; i < regionsCount; i++)
        {
            GameObject gameObject= Instantiate(prefab);
            regions.Add(gameObject);
            region = regions[i].GetComponent<Region>();
            region.regionRot = Quaternion.Euler(90, 0, 0);
            region.id = i;
            regions[i].transform.SetParent(parentMap.transform);
        };
        //
        //settings properties for each region
        //
        region = regions[0].GetComponent<Region>();
        region.name = "Por";
        region.regionPos = new Vector3(-375, -184, 0);
        region.country = countries[7];
        region.hasSupplyCenter = true;

        region = regions[1].GetComponent<Region>();
        region.name = "North Africa";
        region.regionPos = new Vector3(-342, -283, 0);
        region.country = countries[0];
        region.hasSupplyCenter = false;

        region = regions[2].GetComponent<Region>();
        region.name = "Spain";
        region.regionPos = new Vector3(-307, -176, 0);
        region.country = countries[7];
        region.hasSupplyCenter = true;

        region = regions[3].GetComponent<Region>();
        region.name = "Brest";
        region.regionPos = new Vector3(-266, -21, 0);
        region.country = countries[3];
        region.hasSupplyCenter = true;

        region = regions[4].GetComponent<Region>();
        region.name = "Gas";
        region.regionPos = new Vector3(-240, -141, 0);
        region.country = countries[3];
        region.hasSupplyCenter = false;

        region = regions[5].GetComponent<Region>();
        region.name = "Wal";
        region.regionPos = new Vector3(-222, 29, 0);
        region.country = countries[2];
        region.hasSupplyCenter = false;

        region = regions[6].GetComponent<Region>();
        region.name = "Cly";
        region.regionPos = new Vector3(-212, 115, 0);
        region.country = countries[2];
        region.hasSupplyCenter = false;

        region = regions[7].GetComponent<Region>();
        region.name = "Lvp";
        region.regionPos = new Vector3(-204, 70, 0);
        region.country = countries[2];
        region.hasSupplyCenter = true;

        region = regions[8].GetComponent<Region>();
        region.name = "Edi";
        region.regionPos = new Vector3(-194, 122, 0);
        region.country = countries[2];
        region.hasSupplyCenter = true;

        region = regions[9].GetComponent<Region>();
        region.name = "Lon";
        region.regionPos = new Vector3(-188, 30, 0);
        region.country = countries[2];
        region.hasSupplyCenter = true;

        region = regions[10].GetComponent<Region>();
        region.name = "Yor";
        region.regionPos = new Vector3(-188, 57, 0);
        region.country = countries[2];
        region.hasSupplyCenter = false;
        
        region = regions[11].GetComponent<Region>();
        region.name = "Pic";
        region.regionPos = new Vector3(-186, -16, 0);
        region.country = countries[3];
        region.hasSupplyCenter = false;

        region = regions[12].GetComponent<Region>();
        region.name = "Paris";
        region.regionPos = new Vector3(-177, -45, 0);
        region.country = countries[3];
        region.hasSupplyCenter = true;

        region = regions[13].GetComponent<Region>();
        region.name = "Marseilles";
        region.regionPos = new Vector3(-163, -155, 0);
        region.country = countries[3];
        region.hasSupplyCenter = true;

        region = regions[14].GetComponent<Region>();
        region.name = "Bel";
        region.regionPos = new Vector3(-148, 8, 0);
        region.country = countries[0];
        region.hasSupplyCenter = true;
        
        region = regions[15].GetComponent<Region>();
        region.name = "Bur";
        region.regionPos = new Vector3(-143, -58, 0);
        region.country = countries[3];
        region.hasSupplyCenter = false;

        region = regions[16].GetComponent<Region>();
        region.name = "Tunis";
        region.regionPos = new Vector3(-136, -304, 0);
        region.country = countries[7];
        region.hasSupplyCenter = true;
        
        region = regions[17].GetComponent<Region>();
        region.name = "Ruhr";
        region.regionPos = new Vector3(-120, -36, 0);
        region.country = countries[4];
        region.hasSupplyCenter = false;

        region = regions[18].GetComponent<Region>();
        region.name = "Pie";
        region.regionPos = new Vector3(-118, -150, 0);
        region.country = countries[5];
        region.hasSupplyCenter = false;

        region = regions[19].GetComponent<Region>();
        region.name = "Hol";
        region.regionPos = new Vector3(-116, 29, 0);
        region.country = countries[0];
        region.hasSupplyCenter = true;

        region = regions[20].GetComponent<Region>();
        region.name = "Tus";
        region.regionPos = new Vector3(-81, -192, 0);
        region.country = countries[5];
        region.hasSupplyCenter = false;

        region = regions[21].GetComponent<Region>();
        region.name = "Tyrolia";
        region.regionPos = new Vector3(-71, -112, 0);
        region.country = countries[1];
        region.hasSupplyCenter = false;

        region = regions[22].GetComponent<Region>();
        region.name = "Munich";
        region.regionPos = new Vector3(-65, -70, 0);
        region.country = countries[4];
        region.hasSupplyCenter = true;

        region = regions[23].GetComponent<Region>();
        region.name = "Kiel";
        region.regionPos = new Vector3(-65, 25, 0);
        region.country = countries[4];
        region.hasSupplyCenter = true;

        region = regions[24].GetComponent<Region>();
        region.name = "Rom";
        region.regionPos = new Vector3(-64, -206, 0);
        region.country = countries[5];
        region.hasSupplyCenter = true;

        region = regions[25].GetComponent<Region>();
        region.name = "Ven";
        region.regionPos = new Vector3(-54, -132, 0);
        region.country = countries[5];
        region.hasSupplyCenter = true;

        region = regions[26].GetComponent<Region>();
        region.name = "Norway";
        region.regionPos = new Vector3(-42, 146, 0);
        region.country = countries[0];
        region.hasSupplyCenter = true;

        region = regions[27].GetComponent<Region>();
        region.name = "Den";
        region.regionPos = new Vector3(-35, 59, 0);
        region.country = countries[0];
        region.hasSupplyCenter = true;

        region = regions[28].GetComponent<Region>();
        region.name = "Nap";
        region.regionPos = new Vector3(-29, -245, 0);
        region.country = countries[5];
        region.hasSupplyCenter = true;

        region = regions[29].GetComponent<Region>();
        region.name = "Berlin";
        region.regionPos = new Vector3(-24, -7, 0);
        region.country = countries[4];
        region.hasSupplyCenter = true;

        region = regions[30].GetComponent<Region>();
        region.name = "Trieste";
        region.regionPos = new Vector3(-21, -142, 0);
        region.country = countries[1];
        region.hasSupplyCenter = true;

        region = regions[31].GetComponent<Region>();
        region.name = "Vie";
        region.regionPos = new Vector3(-9, -73, 0);
        region.country = countries[1];
        region.hasSupplyCenter = true;

        region = regions[32].GetComponent<Region>();
        region.name = "Boh";
        region.regionPos = new Vector3(-5, -49, 0);
        region.country = countries[1];
        region.hasSupplyCenter = false;

        region = regions[33].GetComponent<Region>();
        region.name = "Apu";
        region.regionPos = new Vector3(5, -251, 0);
        region.country = countries[5];
        region.hasSupplyCenter = false;

        region = regions[34].GetComponent<Region>();
        region.name = "Silesia";
        region.regionPos = new Vector3(16, -39, 0);
        region.country = countries[4];
        region.hasSupplyCenter = false;

        region = regions[35].GetComponent<Region>();
        region.name = "Prussia";
        region.regionPos = new Vector3(19, -5, 0);
        region.country = countries[4];
        region.hasSupplyCenter = false;

        region = regions[36].GetComponent<Region>();
        region.name = "Sweden";
        region.regionPos = new Vector3(22, 133, 0);
        region.country = countries[0];
        region.hasSupplyCenter = true;

        region = regions[37].GetComponent<Region>();
        region.name = "Budapest";
        region.regionPos = new Vector3(33, -98, 0);
        region.country = countries[1];
        region.hasSupplyCenter = true;

        region = regions[38].GetComponent<Region>();
        region.name = "Warsaw";
        region.regionPos = new Vector3(44, -24, 0);
        region.country = countries[6];
        region.hasSupplyCenter = true;

        region = regions[39].GetComponent<Region>();
        region.name = "Alb";
        region.regionPos = new Vector3(55, -246, 0);
        region.country = countries[0];
        region.hasSupplyCenter = false;

        region = regions[40].GetComponent<Region>();
        region.name = "Serbia";
        region.regionPos = new Vector3(65, -171, 0);
        region.country = countries[0];
        region.hasSupplyCenter = true;

        region = regions[41].GetComponent<Region>();
        region.name = "Finland";
        region.regionPos = new Vector3(91, 142, 0);
        region.country = countries[0];
        region.hasSupplyCenter = false;

        region = regions[42].GetComponent<Region>();
        region.name = "Greece";
        region.regionPos = new Vector3(97, -279, 0);
        region.country = countries[0];
        region.hasSupplyCenter = true;

        region = regions[43].GetComponent<Region>();
        region.name = "Livonia";
        region.regionPos = new Vector3(99, 27, 0);
        region.country = countries[6];
        region.hasSupplyCenter = false;

        region = regions[44].GetComponent<Region>();
        region.name = "Bulgaria";
        region.regionPos = new Vector3(105, -200, 0);
        region.country = countries[0];
        region.hasSupplyCenter = true;

        region = regions[45].GetComponent<Region>();
        region.name = "Galicia";
        region.regionPos = new Vector3(107, -74, 0);
        region.country = countries[1];
        region.hasSupplyCenter = false;

        region = regions[46].GetComponent<Region>();
        region.name = "Rumania";
        region.regionPos = new Vector3(147, -134, 0);
        region.country = countries[0];
        region.hasSupplyCenter = true;

        region = regions[47].GetComponent<Region>();
        region.name = "St. Petersburg";
        region.regionPos = new Vector3(150, 125, 0);
        region.country = countries[6];
        region.hasSupplyCenter = true;

        region = regions[48].GetComponent<Region>();
        region.name = "Ukraine";
        region.regionPos = new Vector3(162, -58, 0);
        region.country = countries[6];
        region.hasSupplyCenter = false;

        region = regions[49].GetComponent<Region>();
        region.name = "Smyrna";
        region.regionPos = new Vector3(173, -275, 0);
        region.country = countries[8];
        region.hasSupplyCenter = true;

        region = regions[50].GetComponent<Region>();
        region.name = "Con";
        region.regionPos = new Vector3(186, -207, 0);
        region.country = countries[8];
        region.hasSupplyCenter = true;

        region = regions[51].GetComponent<Region>();
        region.name = "Moscow";
        region.regionPos = new Vector3(239, 69, 0);
        region.country = countries[6];
        region.hasSupplyCenter = true;

        region = regions[52].GetComponent<Region>();
        region.name = "Sevastopol";
        region.regionPos = new Vector3(252, -128, 0);
        region.country = countries[6];
        region.hasSupplyCenter = true;

        region = regions[53].GetComponent<Region>();
        region.name = "Ankara";
        region.regionPos = new Vector3(257, -218, 0);
        region.country = countries[8];
        region.hasSupplyCenter = true;

        region = regions[54].GetComponent<Region>();
        region.name = "Syria";
        region.regionPos = new Vector3(326, -290, 0);
        region.country = countries[0];
        region.hasSupplyCenter = false;

        region = regions[55].GetComponent<Region>();
        region.name = "Armenia";
        region.regionPos = new Vector3(351, -188, 0);
        region.country = countries[0];
        region.hasSupplyCenter = false;           
        
        //
        //setting position, name, material of the regions to the GameObjects
        //
        Shader sh = Shader.Find("Legacy Shaders/Diffuse");
        for (int i = 0; i < regions.Count; i++)
        {
            region = regions[i].GetComponent<Region>();
            regions[i].name = $"#{region.id}: "+region.name+ $" ({region.country.countryName}) "+Convert.ToInt16(region.hasSupplyCenter);
            regions[i].transform.position = region.regionPos;
            MeshRenderer mr = regions[i].GetComponent<MeshRenderer>();
            mr.material.shader = sh;
            mr.material.color = region.country.countryDefaultColor;
            if (region.hasSupplyCenter) mr.material.mainTexture = matSupplyReg;
            else mr.material.mainTexture = matDefaultReg;
        }
        //
        //setting adjacency matrix
        //
        matrix = new List<List<int>>();
        for (int i = 0; i < regions.Count; i++)
        {
            matrix.Add(new List<int>());
            for (int j = 0; j < regions.Count; j++)
            {
                matrix[i].Add(0);
                if (i==j) matrix[i][j] = 1;                
                switch (i)
                {
                    case 0: if (j == 2) { matrix[i][j] = 1; } break;
                    case 1: if (j == 2 || j == 16) { matrix[i][j] = 1; } break;
                    case 2: if (j == 4 || j == 13) { matrix[i][j] = 1; } break;
                    case 3: if (j == 4 || j == 12 || j == 11) { matrix[i][j] = 1; } break;
                    case 4: if (j == 12 || j == 13 || j == 15) { matrix[i][j] = 1; } break;
                    case 5: if (j == 7 || j == 9 || j == 10) { matrix[i][j] = 1; } break;
                    case 6: if (j == 7 || j == 8) { matrix[i][j] = 1; } break;
                    case 7: if (j == 10) { matrix[i][j] = 1; } break;
                    case 8: if (j == 10) { matrix[i][j] = 1; } break;
                    case 9: if (j == 10||j==14) { matrix[i][j] = 1; } break;//extra london - bel

                    case 11: if (j == 12 || j ==14) { matrix[i][j] = 1; } break;
                    case 12: if (j == 15) { matrix[i][j] = 1; } break;
                    case 13: if (j == 15 || j == 18) { matrix[i][j] = 1; } break;
                    case 14: if (j == 15 || j == 17 || j == 19) { matrix[i][j] = 1; } break;
                    case 15: if (j == 17 || j == 22) { matrix[i][j] = 1; } break;
                    case 16: if (j == 28) { matrix[i][j] = 1; } break;//extra tunis - nap
                    case 17: if (j == 19 || j == 22 || j == 23) { matrix[i][j] = 1; } break;
                    case 18: if (j == 20 || j == 21 || j == 25) { matrix[i][j] = 1; } break;
                    case 19: if (j == 23) { matrix[i][j] = 1; } break;

                    case 20: if (j == 24 || j == 25) { matrix[i][j] = 1; } break;
                    case 21: if (j == 22 || j == 25 || j == 30||j == 31|| j == 32) { matrix[i][j] = 1; } break;
                    case 22: if (j == 23 || j == 29 || j == 32 || j == 34) { matrix[i][j] = 1; } break;
                    case 23: if (j == 27 || j == 29) { matrix[i][j] = 1; } break;
                    case 24: if (j == 25 || j == 28 || j == 33) { matrix[i][j] = 1; } break;
                    case 25: if (j == 30 || j == 33) { matrix[i][j] = 1; } break;
                    case 26: if (j == 36 || j == 41 || j == 47) { matrix[i][j] = 1; } break;
                    case 27: if (j == 36) { matrix[i][j] = 1; } break;
                    case 28: if (j == 33) { matrix[i][j] = 1; } break;
                    case 29: if (j == 34 || j == 35) { matrix[i][j] = 1; } break;

                    case 30: if (j == 31 || j == 37 || j == 39 || j == 40) { matrix[i][j] = 1; } break;
                    case 31: if (j == 32 || j == 37 || j == 45) { matrix[i][j] = 1; } break;
                    case 32: if (j == 34 || j == 45) { matrix[i][j] = 1; } break;
                    case 34: if (j == 35 || j == 38 || j == 45) { matrix[i][j] = 1; } break;
                    case 35: if (j == 38 || j == 43) { matrix[i][j] = 1; } break;
                    case 36: if (j == 41) { matrix[i][j] = 1; } break;
                    case 37: if (j == 40 || j == 45 || j == 46) { matrix[i][j] = 1; } break;
                    case 38: if (j == 43 || j == 45 || j == 48 || j == 51) { matrix[i][j] = 1; } break;
                    case 39: if (j == 40 || j == 42) { matrix[i][j] = 1; } break;

                    case 40: if (j == 42 || j == 44 || j == 46) { matrix[i][j] = 1; } break;
                    case 41: if (j == 47) { matrix[i][j] = 1; } break;
                    case 42: if (j == 44) { matrix[i][j] = 1; } break;
                    case 43: if (j == 47 || j == 48 || j == 51) { matrix[i][j] = 1; } break;
                    case 44: if (j == 46 || j == 50) { matrix[i][j] = 1; } break;
                    case 45: if (j == 46 || j == 48) { matrix[i][j] = 1; } break;
                    case 46: if (j == 48 || j == 52) { matrix[i][j] = 1; } break;
                    case 47: if (j == 51) { matrix[i][j] = 1; } break;
                    case 48: if (j == 51 || j == 52) { matrix[i][j] = 1; } break;
                    case 49: if (j == 50 || j == 53 || j == 54 || j == 55) { matrix[i][j] = 1; } break;

                    case 50: if (j == 53) { matrix[i][j] = 1; } break;
                    case 51: if (j == 52) { matrix[i][j] = 1; } break;
                    case 52: if (j == 55) { matrix[i][j] = 1; } break;
                    case 53: if (j == 55) { matrix[i][j] = 1; } break;
                    case 54: if (j == 55) { matrix[i][j] = 1; } break;
                    default: break;
                }
            }

        }
        for (int i = 0; i < matrix.Count-1; i++)
        {            
            for (int j = matrix.Count-1; j > 0; j--)
            {
                if (matrix[i][matrix.Count-j] ==1)matrix[matrix.Count - j][i] = 1;
            }
        }
        /*for (int i = 0; i < matrix.Count; i++)
        {
            string str = "";
            for (int j = 0; j < matrix.Count; j++)
            {
                str += matrix[i][j].ToString();
            }
            str += "\n";
            Debug.Log(str);
        }*/
    }

    void Update()
    {

    }

    public List<GameObject> getRegions()
    {
        return regions;
    }

    public void mapclick(GameObject objClicked)
    {
        Debug.Log("Clicked: " + objClicked.name);
    }

    public void mapMouseDown(GameObject objClicked)
    {
        //Debug.Log("Pointer Down: " + objClicked.name);

        /*MeshRenderer mr = objClicked.GetComponent<MeshRenderer>();
        mr.material.color = colorDefaultRus;*/

        MeshRenderer mr = objClicked.GetComponent<MeshRenderer>();
        mr.material.color = red;
    }

    public void mapMouseUp(GameObject objClicked)
    {
        //Debug.Log("Pointer Up: " + objClicked.name);

    }

    public void mapMouseEnter(GameObject objClicked)
    {
        Debug.Log("Pointer Enter: " + objClicked.name);

        MeshRenderer mr = objClicked.GetComponent<MeshRenderer>();
        mr.material.color = yellow;
    }

    public void mapMouseExit(GameObject objClicked)
    {
        Debug.Log("Pointer Exit: " + objClicked.name);
        MeshRenderer mr = objClicked.GetComponent<MeshRenderer>();
        mr.material.color = red;
        var region = objClicked.GetComponent<Region>();
        mr.material.color = region.country.countryDefaultColor;
    }

    WindowManager windowManager;
    internal void mapLongClick(GameObject objClicked)
    {
        windowManager = new WindowManager();
        Debug.Log("Pointer long click: " + objClicked.name);
        windowManager.openAdditionalWindow(objClicked);
    }

}