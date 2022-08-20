using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SortManager : MonoBehaviour
{
    public List<SortObject> sortObjects;

    public static bool IsSorting = false;
    
    private void GenerateSortObjects()
    {
        #region Generate Sort Object
        GameObject sortObjectPrefab = Addressables.LoadAssetAsync<GameObject>("SortObjectPrefab").WaitForCompletion();
        sortObjectPrefab.GetComponent<SortObject>().Value = Random.Range(0, 999);
        GameObject sortObjectInstance = Instantiate(sortObjectPrefab,
            new Vector3((0.30f * sortObjects.Count), 1, 0), Quaternion.identity);

        sortObjects.Add(sortObjectInstance.GetComponent<SortObject>());
        #endregion

        #region Generate Socket Point
        GameObject socketPointPrefab = Addressables.LoadAssetAsync<GameObject>("SocketPoint").WaitForCompletion();
        
        Instantiate(socketPointPrefab,
            new Vector3((0.30f * sortObjects.Count -0.30f), 1, 0), Quaternion.identity);      
        #endregion

    }

    public void CallGenerateSortObjects()
    {
        for (int i = 0; i < UIManager.Instance.SelectedObjectCount(); i++)
        {
            GenerateSortObjects();
        }             
    }

    public void SortValues()
    {
        IsSorting = true;
        switch (UIManager.Instance.SelectedAlgorithm())
        {
            case 0:
                StartCoroutine(BubbleSort.Instance.Sort(sortObjects, UIManager.Instance.SelectedMultiplier()));
                break;
            case 1:
                StartCoroutine(SelectionSort.Instance.Sort(sortObjects, UIManager.Instance.SelectedMultiplier()));
                break;

            default:
                IsSorting = false;
                break;            
        }       
    }
}
