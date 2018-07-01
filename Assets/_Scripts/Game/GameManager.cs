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

    [Tooltip("Amount of seconds to allow counter weight increments, beginning at the first increment")]
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

    // reset the round, 
    public void Reset(bool onAStreak)
    {
        score = onAStreak ? score++ : 0;

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

        float targetTime = Time.time + timeToIncrementWeight;
        float startTime = Time.time;

        while (Time.time < targetTime)
        {
            canvasManager.timerImage.fillAmount = (Time.time - startTime) / timeToIncrementWeight;
            yield return null;
        }

        if (OnCounterWeightTimeEnd != null)
            OnCounterWeightTimeEnd.Invoke();

        canvasManager.DeactivateUI();

        waitTimeCo = null;
    }

    public void EndRound()
    {
        if(OnRoundEnd != null)
            OnRoundEnd.Invoke();
    }
}
