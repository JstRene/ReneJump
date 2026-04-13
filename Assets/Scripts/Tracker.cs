using UnityEngine;
using TMPro;

public class Tracker : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text respawnText;

    private float elapsedTime = 0f;
    private int respawnCount = 0;
    private bool timerRunning = true;

    void Start()
    {
        UpdateTimeText();
        UpdateRespawnText();
    }

    void Update()
    {
        if (!timerRunning)
            return;

        elapsedTime += Time.deltaTime;
        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        if (timeText != null)
            timeText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    private void UpdateRespawnText()
    {
        if (respawnText != null)
            respawnText.text = $"Respawns: {respawnCount}";
    }

    public void AddRespawn()
    {
        respawnCount++;
        UpdateRespawnText();
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void ResetTracker()
    {
        elapsedTime = 0f;
        respawnCount = 0;
        timerRunning = true;

        UpdateTimeText();
        UpdateRespawnText();
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public int GetRespawnCount()
    {
        return respawnCount;
    }
}