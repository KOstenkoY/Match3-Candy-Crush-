using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Match3
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private GameOver _gameOver;

        [Header("UI")]
        [SerializeField] private Text _remainingText;
        [SerializeField] private Text _remainingSubText;
        [SerializeField] private Text _targetText;
        [SerializeField] private Text _targetSubtext;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Image[] _stars;

        private int _starIndex = 0;

        private void Start ()
        {
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i].enabled = i == _starIndex;
            }
        }

        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();

            int visibleStar = 0;

            if (score >= _level.ScoreFirstStar && score < _level.ScoreSecondStar)
            {
                visibleStar = 1;
            }
            else if  (score >= _level.ScoreSecondStar && score < _level.ScoreThirdStar)
            {
                visibleStar = 2;
            }
            else if (score >= _level.ScoreThirdStar)
            {
                visibleStar = 3;
            }

            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i].enabled = (i == visibleStar);
            }

            _starIndex = visibleStar;
        }

        public void SetTarget(int target) => _targetText.text = target.ToString();

        public void SetRemaining(int remaining) => _remainingText.text = remaining.ToString();

        public void SetRemaining(string remaining) => _remainingText.text = remaining;

        public void SetLevelType(LevelType type)
        {
            switch (type)
            {
                case LevelType.Moves:
                    _remainingSubText.text = "moves remaining";
                    _targetSubtext.text = "target score";
                    break;
                case LevelType.Obstacle:
                    _remainingSubText.text = "moves remaining";
                    _targetSubtext.text = "bubbles remaining";
                    break;
                case LevelType.Timer:
                    _remainingSubText.text = "time remaining";
                    _targetSubtext.text = "target score";
                    break;
            }
        }

        public void OnGameWin(int score)
        {
            _gameOver.ShowWin(score, _starIndex);
            if (_starIndex > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, _starIndex);
            }
        }

        public void OnGameLose() => _gameOver.ShowLose();
    }
}
