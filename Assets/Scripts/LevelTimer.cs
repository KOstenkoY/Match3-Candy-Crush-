using UnityEngine;

namespace Match3
{
    public class LevelTimer : Level
    {

        [SerializeField] private int _timeInSeconds;
        [SerializeField] private int _targetScore;

        private float _timer;

        private void Start ()
        {
            _type = LevelType.Timer;

            _hud.SetLevelType(_type);
            _hud.SetScore(_currentScore);
            _hud.SetTarget(_targetScore);
            _hud.SetRemaining($"{_timeInSeconds / 60}:{_timeInSeconds % 60:00}");
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            _hud.SetRemaining(
                $"{(int) Mathf.Max((_timeInSeconds - _timer) / 60, 0)}:{(int) Mathf.Max((_timeInSeconds - _timer) % 60, 0):00}");

            if (_timeInSeconds - _timer <= 0)
            {
                if (_currentScore >= _targetScore)
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
}
