using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region IU Elements
    public TMP_Dropdown algorithmDropdown;
    public TMP_Dropdown speedMultiplier;
    public TMP_Dropdown objectCount;
    #endregion

    #region Public Vars
    public static UIManager Instance { get; private set; }
    #endregion

    #region Private Vars
    List<string> objectCountList = new List<string>();
    List<string> speedMultiplierList = new List<string>();
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            objectCountList.Add(i.ToString());
        }
        objectCount.AddOptions(objectCountList);

        for (float i = 0; i < 10; i+=0.50f)
        {
            speedMultiplierList.Add(i.ToString());
        }
        speedMultiplier.AddOptions(speedMultiplierList);
    }

    public int SelectedAlgorithm()
    {        
        return algorithmDropdown.value;
    }
    public float SelectedMultiplier()
    {            
        return float.Parse(speedMultiplier.options[speedMultiplier.value].text);
    }
    public int SelectedObjectCount()
    {
        return int.Parse (objectCount.options[objectCount.value].text);
    }
}
