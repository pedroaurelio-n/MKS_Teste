using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PedroAurelio.SOEventSystem;
 
namespace PedroAurelio.MKS
{
    public class SessionDuration : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private GameEvent endSession;
        [SerializeField] private TextMeshProUGUI durationText;

        private float _currentSession;
        private bool _isSessionEnded;

        private void Awake()
        {
            if (gameData.SessionDuration != default)
                _currentSession = gameData.SessionDuration;
            else
                _currentSession = 60f;
        }

        private void Update()
        {
            if (_currentSession > 0f)
            {
                _currentSession -= Time.deltaTime;
                durationText.text = _currentSession.ToString("00");
                return;
            }

            if (!_isSessionEnded)
                EndSession();
        }

        private void EndSession()
        {
            _isSessionEnded = true;
            endSession?.RaiseEvent();
        }
    }
}