using Cinemachine;
using UnityEngine;

/// <summary>
/// Base class for projectiles
/// 
/// Ruben Sanchez
/// 6/29/18
/// </summary>

public class Projectile : MonoBehaviour
{
    [SerializeField] private bool checkTag;
    [SerializeField] private string tagToCheck;
    [SerializeField] private GameObject VCam;
    
    void OnEnable()
    {
        CinemachineManager.Instance.SwitchCams(VCam);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Reset and continue the streak if it hit the tower
        GameManager.Instance.Reset(other.gameObject.CompareTag(tagToCheck));

        Destroy(GetComponent<Collider>());
    }
    


}
