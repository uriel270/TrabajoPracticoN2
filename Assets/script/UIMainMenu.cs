using UnityEngine;
using UnityEngine.UI;
using Clase1;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button CreditsButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button BackButtonSettings;
    [SerializeField] private Button BackButtonCredits;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private Slider speedSliderPlayer1;
    [SerializeField] private Slider speedSliderPlayer2;
    [SerializeField] private Text speedTextPlayer1;
    [SerializeField] private Text speedTextPlayer2;
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;

    private bool isPaused = false;

    private void Awake()
    {
        PlayButton.onClick.AddListener(OnPlayButtonClicked);
        SettingsButton.onClick.AddListener(OnSettingsButtonClicked);
        CreditsButton.onClick.AddListener(OnCreditsButtonClicked);
        ExitButton.onClick.AddListener(OnExitButtonClicked);
        BackButtonSettings.onClick.AddListener(OnBackButtonClicked);
        BackButtonCredits.onClick.AddListener(OnBackButtonClicked);
        speedSliderPlayer1.onValueChanged.AddListener(OnspeedSliderPlayer1Changed);
        speedSliderPlayer2.onValueChanged.AddListener(OnspeedSliderPlayer1Changed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void OnDestroy()
    {
        PlayButton.onClick.RemoveAllListeners();
        SettingsButton.onClick.RemoveAllListeners();
        CreditsButton.onClick.RemoveAllListeners();
        ExitButton.onClick.RemoveAllListeners();
        BackButtonSettings.onClick.RemoveAllListeners();
        BackButtonCredits.onClick.RemoveAllListeners();
        speedSliderPlayer1.onValueChanged.RemoveAllListeners();
        speedSliderPlayer2.onValueChanged.RemoveAllListeners();
    }

    [SerializeField] private void Resume()
                     {
                         pauseMenuUI.SetActive(false);
                         settingsPanel.SetActive(false);
                         CreditsPanel.SetActive(false);
                         isPaused = false;
                     }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    private void OnPlayButtonClicked()
    {
        pauseMenuUI.SetActive(false);

    }

    private void OnSettingsButtonClicked()
    {
        settingsPanel.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    private void OnCreditsButtonClicked()
    {
        CreditsPanel.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void OnBackButtonClicked()
    {
        settingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void OnExitButtonClicked()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); // Cierra el juego en la versión final
        #endif
    }

    private void OnspeedSliderPlayer1Changed(float newSpeed)
    {
        player1.movementSpeed = newSpeed;
            speedTextPlayer1.text = newSpeed.ToString("");
        
    }

    private void OnspeedSliderPlayer2Changed(float newSpeed)
    {
        player2.movementSpeed = newSpeed;
        speedTextPlayer2.text = newSpeed.ToString("");

    }
}