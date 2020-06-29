using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerBlockDestroyed = 10;
    [SerializeField] bool isAutoPlayEnabled;


    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
       
        if (gameStatusCount > 1 )
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    private void Start()
    {
        FindObjectOfType<TextMeshProUGUI>().text = currentScore.ToString();
    }

        // Update is called once per frame
        void Update()
        {
            Time.timeScale = gameSpeed;

        }

        public void AddToScore()
        {

            currentScore += scorePerBlockDestroyed;
            FindObjectOfType<TextMeshProUGUI>().text = currentScore.ToString();
        }

    public void ResetScore()
    {

        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {

        return isAutoPlayEnabled;

    }
}
