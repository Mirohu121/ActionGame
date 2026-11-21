using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;
using NUnit.Framework;
using KTC.Domain;

namespace KTC.Scene
{
    public class GameFlowController : MonoBehaviour
    {

        [SerializeField] private TMP_Text _statusText = null;

        private bool _isGameOver = false;

        public bool IsGameOver
        {
            get { return _isGameOver; }
        }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            SetPlayingState();
        }

        // Update is called once per frame
        void Update()
        {
            if(Keyboard.current !=null && Keyboard.current.rKey.wasPressedThisFrame)
            {
                Retry();
            }
        }

        public void TriggerGameOver()
        {
            if(_isGameOver)
            {
                return;
            }

            _isGameOver=true;

            if(_statusText != null)
            {
                _statusText.text = string.Format(ConstGame.VIEW_GAME_OVER);
            }

        }

        public void Retry()
        {
            UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(currentScene.name);
        }

        private void SetPlayingState()
        {
            _isGameOver = false;

            if(_statusText!=null)
            {
                _statusText.text = string.Format(ConstGame.VIEW_PLAYING);
            }
        }

    }
}
