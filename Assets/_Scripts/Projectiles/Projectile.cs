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
        if(checkTag && other.gameObject.CompareTag(tagToCheck))
            Destroy(other.gameObject);
    }


}
