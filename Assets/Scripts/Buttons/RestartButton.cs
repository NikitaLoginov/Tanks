using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button _restartButton;

    private void Awake()
    {
        _restartButton = GetComponent<Button>();
        _restartButton.onClick.AddListener(EventBroker.CallRestartGame);
    }
}
