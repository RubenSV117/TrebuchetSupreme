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
    private RoundManager counterWeightManager;

    void Awake()
    {
        anim = GetComponent<Animator>();

        counterWeightManager = GetComponent<RoundManager>();
        counterWeightManager.OnCounterWeightTimeEnd += PlayLaunch;
    }

    public void PlayLaunch()
    {
        anim.Play("Launch");
    }
}
