using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages counter weight for the Superior Seige Weapon
/// 
/// Ruben Sanchez
/// 6/29/18
/// </summary>

public class CounterWeightManager : MonoBehaviour 
{
    public float counterWeight { get; private set; }

    [Tooltip("Amount to increase the current counter weight by")]
    [SerializeField] private float counterWeightIncrement = 2f;

    public void AddCounterWeight()
    {
        // add counter weight which will be used as the velocity magnitude
        counterWeight += counterWeightIncrement;
    }
}
