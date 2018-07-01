using UnityEngine;

/// <summary>
/// Controls Animations
/// 
/// Ruben Sanchez
/// 6/29/18
/// </summary>

public class AnimationManager : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameManager gameManager;

    void Awake()
    {
        anim = GetComponent<Animator>();
        gameManager.OnCounterWeightTimeEnd += PlayLaunch;
    }

    public void PlayLaunch()
    {
        anim.Play("Launch");
    }
}
