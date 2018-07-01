using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages UI elements 
/// 
/// Ruben Sanchez
/// 
/// </summary>

public class CanvasManager : MonoBehaviour 
{
    [Tooltip("Button used to add weight, deactivated on timer end")]
    [SerializeField] private GameObject counterWeightButton;

    [Tooltip("Slider used to turn the trebuchet")]
    [SerializeField] private GameObject turnBar;

    [Tooltip("Arrows used to show direction of wind resistance")]
    [SerializeField] private GameObject windArrows;

    [Tooltip("Button Filled in according to time left to add weight")]
    public Image timerImage;

    [SerializeField] private Text ScoreText;

    void Awake()
    {
        GameManager.OnRoundStart += ResetUI;
        GameManager.OnRoundStart += SetScore;
    }

    public void ResetUI()
    {
        windArrows.SetActive(true);
        counterWeightButton.SetActive(true);
        turnBar.SetActive(true);
        timerImage.gameObject.SetActive(true);
        timerImage.fillAmount = 0;
    }

    public void DeactivateUI()
    {
        counterWeightButton.SetActive(false);
        timerImage.gameObject.SetActive(false);
        turnBar.SetActive(false);
        windArrows.SetActive(false);
    }

    public void SetScore()
    {
        ScoreText.text = "" + GameManager.Instance.score;
    }
}
