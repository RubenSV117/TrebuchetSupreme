using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Applies a Force to rigidbody within collider
/// 
/// Ruben Sanchez
/// 
/// </summary>

public class WindResistance : MonoBehaviour
{
    [SerializeField] private GameObject resistanceArrow;
    [SerializeField] private Text resistanceText;

    [SerializeField] private bool checkTag;
    [SerializeField] private string tagToCheck;

    [SerializeField] private float maxResistanceMagnitude;


    private Rigidbody rigidB;
    private float currentResistance;

    void Awake()
    {
        GameManager.OnRoundStart += CalculateNewResistance;
        GameManager.OnRoundStart += ResetCurrentRigidbody;
    }

    public void CalculateNewResistance()
    {
        currentResistance = Random.Range(-maxResistanceMagnitude, maxResistanceMagnitude);

        resistanceArrow.transform.localScale = new Vector3(currentResistance > 0 ? 1 : -1, 1, 1);
        resistanceText.text = "" + currentResistance.ToString("F1");
    }

    public void OnTriggerStay(Collider other)
    {
        if (!checkTag || checkTag && other.CompareTag(tagToCheck))
        {
            if (rigidB == null)
                rigidB = other.attachedRigidbody;

            rigidB.AddForce(rigidB.transform.right * currentResistance, ForceMode.Force);
        }
    }

    public void ResetCurrentRigidbody()
    {
        rigidB = null;
    }
}
