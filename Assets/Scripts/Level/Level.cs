using System.Collections;
using UnityEngine;

namespace Match3
{
    public class Level : MonoBehaviour
    {
        [Header("Level settings")]
        [SerializeField] protected GameGrid _gameGrid;
        [SerializeField] protected Hud _hud;

        [SerializeField] private int _scoreFirstStar;
        [SerializeField] private int _scoreSecondStar;
        [SerializeField] private int _scoreThirdStar;

        protected LevelType _type;

        protected int _currentScore;

        private bool _didWin;

        public int ScoreFirstStar => _scoreFirstStar;
        public int ScoreSecondStar => _scoreSecondStar;
        public int ScoreThirdStar => _scoreThirdStar;

        private void Start()
        {
            _hud.SetScore(_currentScore);
        }

        public LevelType Type => _type;

        protected virtual void GameWin()
        {
            _gameGrid.GameOver();
            _didWin = true;
            StartCoroutine(WaitForGridFill());
        }

        protected virtual void GameLose()
        {        
            _gameGrid.GameOver();
            _didWin = false;
            StartCoroutine(WaitForGridFill());
        }
    
        public virtual void OnMove()
        {
        }

        public virtual void OnPieceCleared(GamePiece piece)
        {
            _currentScore += piece.Score;
            _hud.SetScore(_currentScore);
        }

        protected virtual IEnumerator WaitForGridFill()
        {
            while (_gameGrid.IsFilling)
            {
                yield return null;
            }

            if (_didWin)
            {
                _hud.OnGameWin(_currentScore);
            }
            else
            {
                _hud.OnGameLose();
            }
        }
    }
}
