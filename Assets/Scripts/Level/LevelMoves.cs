namespace Match3
{
    public class LevelMoves : Level
    {
        public int _numMoves;
        public int targetScore;

        private int _movesUsed = 0;

        private void Start()
        {
            _type = LevelType.Moves;

            _hud.SetLevelType(_type);
            _hud.SetScore(_currentScore);
            _hud.SetTarget(targetScore);
            _hud.SetRemaining(_numMoves);
        }

        public override void OnMove()
        {
            _movesUsed++;

            _hud.SetRemaining(_numMoves - _movesUsed);

            if (_numMoves - _movesUsed != 0) return;
        
            if (_currentScore >= targetScore)
            {
                GameWin();
            }
            else
            {
                GameLose();
            }
        }
    }
}
