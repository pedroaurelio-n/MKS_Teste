using UnityEngine;
using TMPro;
using PedroAurelio.SOEventSystem;
 
namespace PedroAurelio.MKS
{
    public class SessionDuration : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData gameData;

        [Header("Events")]
        [SerializeField] private GameEvent endSession;

        [Header("Dependencies")]
        [SerializeField] private TextMeshProUGUI durationText;

        private float _currentSession;
        private bool _isSessionEnded;

        private void Awake() => _currentSession = gameData.SessionDuration;

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