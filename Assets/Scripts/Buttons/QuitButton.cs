using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button _quitButton;

    private void Awake()
    {
        _quitButton = GetComponent<Button>();
        _quitButton.onClick.AddListener(EventBroker.CallQuitGame);
    }
}
