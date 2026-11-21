using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using KTC.Domain;

namespace KTC.Scene
{
    public class GameFlowController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _statusText = null;
        [SerializeField] private TMP_Text _countdownText = null;
        [SerializeField] private GameObject _gameOverPanel = null;

        private bool _isGameOver = false;
        private bool _isCountingDown = true;

        public bool IsGameOver
        {
            get { return _isGameOver; }
        }

        public bool IsCountingDown
        {
            get { return _isCountingDown; }
        }

        private void Start()
        {
            SetInitialState();
            StartCoroutine(CountdownRoutine());
        }

        private void Update()
        {
            if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            {
                Retry();
            }
        }

        public void TriggerGameOver()
        {
            if (_isGameOver)
            {
                return;
            }

            _isGameOver = true;

            if (_gameOverPanel != null)
            {
                _gameOverPanel.SetActive(true);
            }

            if (_statusText != null)
            {
                _statusText.text = string.Format(ConstGame.VIEW_GAME_OVER);
            }
        }

        public void Retry()
        {
            UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        private void SetInitialState()
        {
            _isGameOver = false;
            _isCountingDown = true;

            if (_gameOverPanel != null)
            {
                _gameOverPanel.SetActive(false);
            }

            if (_countdownText != null)
            {
                _countdownText.gameObject.SetActive(true);
            }

            if (_statusText != null)
            {
                _statusText.text = string.Format(ConstGame.VIEW_PLAYING);
            }
        }

        private IEnumerator CountdownRoutine()
        {
            SetCountdownText(ConstGame.VIEW_COUNT_THREE);
            yield return new WaitForSeconds(ConstGame.COUNTDOWN_STEP_SECONDS);

            SetCountdownText(ConstGame.VIEW_COUNT_TWO);
            yield return new WaitForSeconds(ConstGame.COUNTDOWN_STEP_SECONDS);

            SetCountdownText(ConstGame.VIEW_COUNT_ONE);
            yield return new WaitForSeconds(ConstGame.COUNTDOWN_STEP_SECONDS);

            SetCountdownText(ConstGame.VIEW_START);
            _isCountingDown = false;

            yield return new WaitForSeconds(ConstGame.COUNTDOWN_STEP_SECONDS);

            if (_countdownText != null)
            {
                _countdownText.gameObject.SetActive(false);
            }
        }

        private void SetCountdownText(string message)
        {
            if (_countdownText != null)
            {
                _countdownText.text = string.Format("{0}", message);
            }
        }
    }
}