using System.Collections;
using System.Collections.Generic;
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

    [Tooltip("Counterweights to spawn and drop into the weight bucket")]
    [SerializeField] private List<GameObject> counterWeightObjects;

    [Tooltip("Offset to spawn the counterweight objects ")]
    [SerializeField] private float maxOffSetToSpawn;

    [SerializeField] private Transform counterWeightObjectSpawnPoint;

    [Tooltip("Amount to increase the current counter weight by")]
    [SerializeField] private float counterWeightIncrement = 2f;

    private List<GameObject> counterWeightObjectsSpawned = new List<GameObject>();

    void Awake()
    {
        GameManager.OnRoundStart += ResetWeight;
    }

    public void AddCounterWeight()
    {
        // add counter weight which will be used as the velocity magnitude
        counterWeight += counterWeightIncrement;

        Vector3 spawnPoint = counterWeightObjectSpawnPoint.position + new Vector3(Random.Range(-maxOffSetToSpawn, maxOffSetToSpawn),
                                 Random.Range(-maxOffSetToSpawn, maxOffSetToSpawn), Random.Range(-maxOffSetToSpawn, maxOffSetToSpawn));

        counterWeightObjectsSpawned.Add(Instantiate(counterWeightObjects[Random.Range(0, counterWeightObjects.Count)], spawnPoint, Quaternion.identity));
    }

    public void ResetWeight()
    {
        counterWeight = 0;

        foreach (GameObject obj in counterWeightObjectsSpawned)
            Destroy(obj);
    }
}
