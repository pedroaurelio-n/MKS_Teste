using UnityEngine;
using UnityEngine.UI;

namespace PedroAurelio.MKS
{
    public class OptionsButtonHighlight : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData gameData;

        [Header("Settings")]
        [SerializeField] private OptionType buttonOptionType;
        [SerializeField] private float buttonValue;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void Start() => UpdateButtonState();

        public void UpdateButtonState()
        {
            switch (buttonOptionType)
            {
                case OptionType.SessionDuration:
                    if (gameData.SessionDuration == buttonValue)
                        _button.interactable = false;
                    else
                        _button.interactable = true;

                    break;
                
                case OptionType.EnemySpawn:
                    if (gameData.EnemySpawnTime == buttonValue)
                        _button.interactable = false;
                    else
                        _button.interactable = true;

                    break;
            }
        }

        enum OptionType
        {
            SessionDuration,
            EnemySpawn
        }
    }
}