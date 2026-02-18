using System;
using TMPro;
using UnityEngine;

public class GameBehavior : MonoBehaviour {
    public static GameBehavior Instance;

    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI LifeText;
    [SerializeField] private TextMeshProUGUI LoseText;

    private int _score;

    public int Score {
        get => _score;
        private set => _score = value;
    }

    public int Lives { private set; get; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        Lives = 3;
        
        SpawnBall();
        UpdateTextUI();
    }

    private void SpawnBall() {
        Instantiate(BallPrefab, Vector2.zero, Quaternion.identity);
    }

    private void LoseGame() {
        LoseText.gameObject.SetActive(true);
    }

    private void UpdateTextUI() {
        LifeText.text = $"Lives: {Lives}";
        ScoreText.text = $"Score: {Score}";
    }

    public void Death() {
        Lives--;
        UpdateTextUI();
        if (Lives == 0) {
            LoseGame();
            return;
        }
        Invoke(nameof(SpawnBall), 3);
    }

    public void BreakBrick() {
        Score++;
        UpdateTextUI();
    }
}