using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerName;

    [SerializeField] private TextMeshProUGUI highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        // Display name and high score
        highScore.text = "High score: " + GameManager.Instance.namePlayerHighScore + " : " +
                         GameManager.Instance.highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerName.text != "")
            GameManager.Instance.namePlayer = playerName.text;
    }

    public void LoadMainScence()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
        
    }
}
