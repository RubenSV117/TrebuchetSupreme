using UnityEngine;

/// <summary>
/// Sets this transforms distance from a starting point within a maximum offset
/// 
/// Ruben Sanchez
/// 6/30/18
/// </summary>

public class SetDistanceFromTransform : MonoBehaviour
{
    [SerializeField] private float maxDistanceFromStarting;
    [SerializeField] private Transform transformToMoveTowards;

    private Vector3 startingPosition;

    void Awake()
    {
        GameManager.OnRoundStart += SetDistance;
    }

	void Start () 
	{
	    startingPosition = transform.position;
    }

    public void SetDistance()
    {
        Vector3 direction = (transformToMoveTowards.position - transform.position).normalized;
        float offset = Random.Range(0, maxDistanceFromStarting);

        Vector3 newPosition = startingPosition + direction * offset;

        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}
