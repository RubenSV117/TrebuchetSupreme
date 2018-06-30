using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages round consisting of one launch 
/// Ruben Sanchez
/// 
/// </summary>

public class RoundManager : MonoBehaviour 
{
    // events to fire when timer has begun and ended
    public delegate void CounterWeightTime();

    public event CounterWeightTime OnCounterWeightTimeStart;
    public event CounterWeightTime OnCounterWeightTimeEnd;

    [Tooltip("Amount of seconds to allow counter weight increments, beginning at the first increment")]
    [SerializeField] private float timeToIncrementWeight;

    // button used to add weight, deactivated on timer end
    [SerializeField] private GameObject counterWeightButton;

    [SerializeField] private GameObject turnBar;

    [SerializeField]private Image timerImage;


    private Coroutine waitTimeCo;

    public void BeginRound()
    {
        counterWeightButton.SetActive(true);
        turnBar.SetActive(true);
        timerImage.fillAmount = 0;
    }

    public void BeginRoundTimer()
    {
        // begin the timer
        if (waitTimeCo == null)
            waitTimeCo = StartCoroutine(CounterWeightTimer());
    }

    private IEnumerator CounterWeightTimer()
    {
        if (OnCounterWeightTimeStart != null)
            OnCounterWeightTimeStart.Invoke();

        float targetTime = Time.time + timeToIncrementWeight;
        float startTime = Time.time;

        while (Time.time < targetTime)
        {
            timerImage.fillAmount = (Time.time - startTime) / timeToIncrementWeight;
            yield return null;
        }

        if (OnCounterWeightTimeEnd != null)
            OnCounterWeightTimeEnd.Invoke();

        counterWeightButton.SetActive(false);
        timerImage.gameObject.SetActive(false);
        turnBar.SetActive(false);
        waitTimeCo = null;
    }
}
