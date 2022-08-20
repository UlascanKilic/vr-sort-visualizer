using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SortAlgorithm<T> : MonoBehaviour
{      
    protected static bool Greater(int v, int w)
    {
        return v > w;
    }
    protected static bool Swap(List<SortObject> array, int firstIndex, int secondIndex)
    {
        int swap = array[firstIndex].Value;
        array[firstIndex].Value = array[secondIndex].Value;
        array[secondIndex].Value = swap;
        return true;
    }
    
    protected static void Colorize(SortObject one, Color oneColor,  SortObject two, Color twoColor)
    {
        one.gameObject.GetComponent<Renderer>().material.SetColor("_Color", oneColor);
        two.gameObject.GetComponent<Renderer>().material.SetColor("_Color", twoColor);
    }
    protected static void Colorize(SortObject one, Color oneColor)
    {
        one.gameObject.GetComponent<Renderer>().material.SetColor("_Color", oneColor);
    }
    protected static void ClearColors(SortObject one, SortObject two)
    {
        one.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        two.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }
    protected static void ClearColors(SortObject one)
    {
        one.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
    }
}
