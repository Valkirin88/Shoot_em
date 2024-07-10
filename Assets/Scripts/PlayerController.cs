
public class PlayerController 
{
    private InputController _inputController;
    private PlayerView _playerView;

    public PlayerController(InputController inputController, PlayerView playerView)
    {
        _inputController = inputController;
        _playerView = playerView;
        _inputController.OnDirectionChange += _playerView.SetDirection;
        _inputController.OnShot += _playerView.Shot;
    }


    public void Destroy()
    {
        _inputController.OnDirectionChange -= _playerView.SetDirection;
        _inputController.OnShot -= _playerView.Shot;
    }

}
