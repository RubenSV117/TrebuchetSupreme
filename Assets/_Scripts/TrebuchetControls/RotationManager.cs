using UnityEngine;

/// <summary>
/// Rotates a transform with a slider
/// 
/// Ruben Sanchez
/// 
/// </summary>

public class RotationManager : MonoBehaviour
{
    [SerializeField] private bool invertRotation;
    [SerializeField] private Transform transformToRotate;

    [Tooltip("The biggest amount the transform can rotate about an axis from its original rotation")]
    [SerializeField] private float maxAngleTheta;

    [SerializeField] private bool rotateXAxis;
    [SerializeField] private bool rotateYAxis;
    [SerializeField] private bool rotateZAxis;

    [SerializeField] private float damping = 1;

    private float targetValue;
    private float currentValue;

    void Update()
    {
        currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime / damping);

        transformToRotate.localEulerAngles = new Vector3(rotateXAxis ? (invertRotation ? -currentValue : currentValue) * maxAngleTheta : transform.eulerAngles.x,
            rotateYAxis ? (invertRotation ? -currentValue : currentValue) * maxAngleTheta : transform.eulerAngles.y,
            rotateZAxis ? (invertRotation ? -currentValue : currentValue) * maxAngleTheta : transform.eulerAngles.z);
    }

    public void Rotate(float value)
    {
        targetValue = value;
    }
}
