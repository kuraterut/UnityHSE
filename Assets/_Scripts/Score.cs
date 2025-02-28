using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class Score : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateScore(int score)
        {
            _scoreText.text = "Score: " + score.ToString();
        }
    }
}