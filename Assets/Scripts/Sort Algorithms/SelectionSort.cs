using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSort : SortAlgorithm<SortObject>
{
    public static SelectionSort Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public IEnumerator Sort(List<SortObject> unsorted, float speedMultiplier)
    {
        WaitForSeconds wait = new WaitForSeconds(1f / speedMultiplier);
        int previousBiggest = -1;

        for (int i = 0, size = unsorted.Count; i < size - 1; i++)
        {
            bool swapped = false;
            int biggestIndex = size - i - 1;

            for (int j = 0; j < size - i - 1; j++)
            {             

                Colorize(unsorted[j], Color.green, unsorted[size - i - 1],Color.red);

                yield return wait;

                if (Greater(unsorted[j].Value, unsorted[biggestIndex].Value))
                {
                    if (previousBiggest >= 0)
                        ClearColors(unsorted[previousBiggest]);

                    biggestIndex = j;   
                    previousBiggest = biggestIndex;
                }

                ClearColors(unsorted[j], unsorted[size - i - 1]);
                Colorize(unsorted[biggestIndex], Color.blue);
            }
            if (Greater(unsorted[biggestIndex].Value, unsorted[size - i - 1].Value))
            {
                swapped = Swap(unsorted, biggestIndex, size - i - 1);

                if (previousBiggest >= 0)
                    ClearColors(unsorted[previousBiggest]);

                previousBiggest = biggestIndex;
            }

            ClearColors(unsorted[i]);
        }
        
        yield return unsorted;
    }
}
