using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Match3
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _screenParent;
        [SerializeField] private GameObject _scoreParent;
        [SerializeField] private Text _loseText;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Image[] _stars;

        private void Start ()
        {
            _screenParent.SetActive(false);

            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i].enabled = false;
            }
        }

        public void ShowLose()
        {
            _screenParent.SetActive(true);
            _scoreParent.SetActive(false);

            Animator animator = GetComponent<Animator>();

            if (animator)
            {
                animator.Play("GameOverShow");
            }
        }

        public void ShowWin(int score, int starCount)
        {
            _screenParent.SetActive(true);
            _loseText.enabled = false;

            _scoreText.text = score.ToString();
            _scoreText.enabled = false;

            Animator animator = GetComponent<Animator>();

            if (animator)
            {
                animator.Play("GameOverShow");
            }

            StartCoroutine(ShowWinCoroutine(starCount));
        }

        private IEnumerator ShowWinCoroutine(int starCount)
        {
            yield return new WaitForSeconds(0.5f);

            if (starCount < _stars.Length)
            {
                for (int i = 0; i <= starCount; i++)
                {
                    _stars[i].enabled = true;

                    if (i > 0)
                    {
                        _stars[i - 1].enabled = false;
                    }

                    yield return new WaitForSeconds(0.5f);
                }
            }

            _scoreText.enabled = true;
        }

        public void OnReplayClicked()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        public void OnDoneClicked()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
        }

    }
}
