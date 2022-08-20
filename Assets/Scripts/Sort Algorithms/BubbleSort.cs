using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BubbleSort : SortAlgorithm<SortObject>
{
    public static BubbleSort Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator Sort(List<SortObject> unsorted, float speedMultiplier)
    {
        WaitForSeconds wait = new WaitForSeconds(1f/speedMultiplier);
        int previousSwapped = -1;
        for (int i = 0, size = unsorted.Count - 1; i < size; i++)
        {
            bool swapped = false;
            for (int j = 0; j < size - i; j++)
            {
                if (previousSwapped >= 0)
                    Colorize(unsorted[previousSwapped], Color.blue);

                Colorize(unsorted[j],Color.green, unsorted[j + 1],Color.red);
                
                yield return wait;

                if (Greater(unsorted[j].Value, unsorted[j + 1].Value))
                {                
                    swapped = Swap(unsorted, j, j + 1);

                    if (previousSwapped >= 0)
                        ClearColors(unsorted[previousSwapped]);

                    previousSwapped = j;                
                }

                ClearColors(unsorted[j], unsorted[j + 1]);
            }
            if (!swapped) yield return unsorted;
        }
        yield return unsorted;
    }   
}
