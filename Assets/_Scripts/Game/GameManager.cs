using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages rounds
///
/// Ruben Sanchez
/// 6/29/18
/// </summary>

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // events for round begin and end
    public delegate void RoundPhase();
    public static event RoundPhase OnRoundStart;
    public static event RoundPhase OnRoundEnd;

    // events to fire when timer has begun and ended
    public delegate void CounterWeightTime();
    public event CounterWeightTime OnCounterWeightTimeStart;
    public event CounterWeightTime OnCounterWeightTimeEnd;

    [Tooltip("Amount of seconds allowed to add counter weight, begins counting at the first increment")]
    [SerializeField] private float timeToIncrementWeight;

    [SerializeField] private CanvasManager canvasManager;

    private Coroutine waitTimeCo;

    public int score { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        Reset(false);
    }

    // reset the round, if the tower was hit on the last launch then continue adding to the score
    public void Reset(bool onAStreak)
    {
        score = onAStreak ? score + 1 : 0;

        if (OnRoundStart != null)
            OnRoundStart.Invoke();
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

        // wait the set amount of time and increase the timer fill amount
        float targetTime = Time.time + timeToIncrementWeight;
        float startTime = Time.time;

        while (Time.time < targetTime)
        {
            canvasManager.timerImage.fillAmount = (Time.time - startTime) / timeToIncrementWeight;
            yield return null;
        }

        if (OnCounterWeightTimeEnd != null)
            OnCounterWeightTimeEnd.Invoke();

        // hide UI during launch
        canvasManager.DeactivateUI();

        waitTimeCo = null;
    }

    public void EndRound()
    {
        if(OnRoundEnd != null)
            OnRoundEnd.Invoke();
    }
}
