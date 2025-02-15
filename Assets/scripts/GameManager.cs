using UnityEngine;
using TMPro; // Import TextMeshPro

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText; // UI reference
    private FallTrigger[] pins;

    private void Start()
    {
        // Find all objects with FallTrigger attached
        pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None);

        // Subscribe to each pin's fall event
        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

        // Initialize the UI score display
        UpdateScoreText();
    }

    private void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}