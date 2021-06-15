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
        GameManager.Instance.namePlayer = playerName.text;
    }

    // Update is called once per frame
    void Update()
    {
        
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
