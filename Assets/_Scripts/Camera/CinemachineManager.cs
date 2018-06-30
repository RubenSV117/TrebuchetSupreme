using UnityEngine;

/// <summary>
/// Manages cinemachine vcams in the scene and keeps a reference to current active cam
/// 
/// Ruben Sanchez
/// 6/29/18
/// </summary>

public class CinemachineManager : MonoBehaviour
{
    public static CinemachineManager Instance;

    [HideInInspector]
    public GameObject activeCam;

    [SerializeField] private GameObject defaultCam;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        activeCam = defaultCam;
    }

    public void SwitchCams(GameObject newCam)
    {
        activeCam.SetActive(false);

        activeCam = newCam;
        activeCam.SetActive(true);
    }
}
