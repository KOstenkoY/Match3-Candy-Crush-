using UnityEngine;

namespace Match3
{
    public class LevelSelect : ScenesManager
    {
        [System.Serializable]
        public struct ButtonPlayerPrefs
        {
            public GameObject gameObject;
            public string playerPrefKey;
        };

        [SerializeField] private ButtonPlayerPrefs[] _buttons;

        private void Start()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                int score = PlayerPrefs.GetInt(_buttons[i].playerPrefKey, 0);

                for (int starIndex = 1; starIndex <= 3; starIndex++)
                {
                    Transform star = _buttons[i].gameObject.transform.Find($"star{starIndex}");
                    star.gameObject.SetActive(starIndex <= score);                
                }
            }
        }

        public void OnButtonPress(string levelName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
        }

        public void OpenMainMenu()
        {
            BackToMainMenu();
        }
    }
}
