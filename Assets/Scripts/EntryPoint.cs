using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView;
    [SerializeField]
    private SimpleTouchController _simpleTouchController;

    private InputController _inputController;
    private PlayerController _playerController;
    

    private void Start()
    {
        _inputController = new InputController(_simpleTouchController);
        _playerController = new PlayerController(_inputController, _playerView);
    }

    private void Update()
    {
        _inputController.Update();
    }

    private void OnDestroy()
    {
        _playerController.Destroy();
    }
}
