using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSystem : MonoBehaviour {

    private Dictionary<string, int> _stats = new Dictionary<string, int>();

    public void StateChanged(string statType, int value)
    {
        _stats[statType] += value;
    }
}
