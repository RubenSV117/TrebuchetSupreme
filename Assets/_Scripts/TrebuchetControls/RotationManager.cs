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

    public void Rotate(float value)
    {
        transformToRotate.localEulerAngles = new Vector3(rotateXAxis ? (invertRotation ? -value : value) * maxAngleTheta : transform.eulerAngles.x, 
            rotateYAxis ? (invertRotation ? -value : value) * maxAngleTheta : transform.eulerAngles.y,
            rotateZAxis ? (invertRotation ? -value : value) * maxAngleTheta : transform.eulerAngles.z);

    }
}
