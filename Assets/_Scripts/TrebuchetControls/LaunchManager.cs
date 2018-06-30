using UnityEngine;

/// <summary>
/// Manages Launching for the Superior Seige Weapon
/// Recieves counter weight info from CounterWeightManager
/// 
/// Ruben Sanchez
/// 6/29/18
/// </summary>

public class LaunchManager : MonoBehaviour
{
  
    [Tooltip("Projectile to launch")]
    [SerializeField] private GameObject projectile;

    [Tooltip("Position to launch projectile from, this transform's forward vector will be the projetiles velocity direction")]
    [SerializeField] private Transform firePoint;

    private CounterWeightManager counterWeightManager;

    void Awake()
    {
        counterWeightManager = GetComponent<CounterWeightManager>();
    }


    public void Fire()
    {
        Rigidbody projectile = Instantiate(this.projectile, firePoint.position, firePoint.rotation).GetComponent<Rigidbody>();
        projectile.velocity = firePoint.forward * counterWeightManager.counterWeight;
    }
}
