using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Update()
    {
        if (DayChange.localCounts < 1)
        {
            Destroy(gameObject);
        }
    }
}
