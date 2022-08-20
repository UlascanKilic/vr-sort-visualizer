using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SortObject : MonoBehaviour
{
    public int Value { get { return value; } set { this.value = value; } }

    [SerializeField] private int value;

    private void FixedUpdate()
    {
        this.gameObject.GetComponentInChildren<TMP_Text>().text = Value.ToString();
    }
}
