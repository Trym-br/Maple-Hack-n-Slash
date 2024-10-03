using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    private float _updateTimer = 1f;
    void Update()
    {
        if (_updateTimer <= 0f)
        {
            scoreText.text = PlayerController.Score.ToString();
            _updateTimer = 1f;
        }
        _updateTimer -= Time.deltaTime;
    }
}
