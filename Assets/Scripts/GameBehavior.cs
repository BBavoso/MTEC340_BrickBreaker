using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameBehavior : MonoBehaviour {
    public static GameBehavior Instance;

    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI LifeText;
    [SerializeField] private TextMeshProUGUI LoseText;
    [SerializeField] private TextMeshProUGUI PauseText;

    [SerializeField] private InputActionReference PauseGame;

    private int _score;

    public int Score {
        get => _score;
        private set => _score = value;
    }

    public int Lives { private set; get; }

    public Utilities.GameState GameState;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        PauseGame.action.performed += _ => {
            bool gamePlaying = GameState == Utilities.GameState.Playing;
            GameState = gamePlaying
                ? Utilities.GameState.Paused
                : Utilities.GameState.Playing;
            PauseText.gameObject.SetActive(gamePlaying);
        };
    }

    private void Start() {
        Lives = 3;
        GameState = Utilities.GameState.Playing;

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