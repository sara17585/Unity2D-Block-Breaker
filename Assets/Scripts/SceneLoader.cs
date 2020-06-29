using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{

    // Start is called before the first frame update
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);


    }

    public void LoadStartScene()
    {
       
        //FindObjectOfType<TextMeshProUGUI>().text = "0";
        SceneManager.LoadScene("level 1");
        FindObjectOfType<GameStatus>().ResetScore();
    }

    public void QuitGame()
    {
        
        Application.Quit();
        
    }
}


