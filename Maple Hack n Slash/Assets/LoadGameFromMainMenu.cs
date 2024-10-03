using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameFromMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
