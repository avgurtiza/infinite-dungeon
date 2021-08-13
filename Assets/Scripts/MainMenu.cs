using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Button StartNewGame;
    public Button ResumeSavedGame;
    public Button ViewCredits;
    public Button ExitGame;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main menuing...");

        StartNewGame.onClick.AddListener(LoadNewGameListener);
        ResumeSavedGame.onClick.AddListener(ResumeGameListener);
        ViewCredits.onClick.AddListener(ViewCreditsListener);
        ViewCredits.onClick.AddListener(ViewCreditsListener);
        ExitGame.onClick.AddListener(ExitGameListener);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadNewGameListener() {
        Debug.Log("Load");
        SceneManager.LoadScene("Foyer", LoadSceneMode.Single);
    }

    private void ResumeGameListener() {
        Debug.Log("Resume");
    }

    private void ViewCreditsListener() {
        Debug.Log("Credits");
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }    

    private void ExitGameListener() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
