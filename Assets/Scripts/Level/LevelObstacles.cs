namespace Match3
{
    public class LevelObstacles : Level
    {

        public int numMoves;
        public PieceType[] obstacleTypes;

        private const int ScorePerPieceCleared = 1000;
    
        private int _movesUsed = 0;
        private int _numObstaclesLeft;

        private void Start ()
        {
            _type = LevelType.Obstacle;

            for (int i = 0; i < obstacleTypes.Length; i++)
            {
                _numObstaclesLeft += _gameGrid.GetPiecesOfType(obstacleTypes[i]).Count;
            }

            _hud.SetLevelType(_type);
            _hud.SetScore(_currentScore);
            _hud.SetTarget(_numObstaclesLeft);
            _hud.SetRemaining(numMoves);
        }

        public override void OnMove()
        {
            _movesUsed++;

            _hud.SetRemaining(numMoves - _movesUsed);

            if (numMoves - _movesUsed == 0 && _numObstaclesLeft > 0)
            {
                GameLose();
            }
        }

        public override void OnPieceCleared(GamePiece piece)
        {
            base.OnPieceCleared(piece);

            for (int i = 0; i < obstacleTypes.Length; i++)
            {
                if (obstacleTypes[i] != piece.Type) continue;
            
                _numObstaclesLeft--;
                _hud.SetTarget(_numObstaclesLeft);
                if (_numObstaclesLeft != 0) continue;
            
                _currentScore += ScorePerPieceCleared * (numMoves - _movesUsed);
                _hud.SetScore(_currentScore);
                GameWin();
            }
        }
    }
}
