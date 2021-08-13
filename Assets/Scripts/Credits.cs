using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Button MainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.onClick.AddListener(MainMenuListener);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MainMenuListener() {
        Debug.Log("Main menu");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
