using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    private InputController _inputController;
    private PlayerView _playerView;

    public PlayerController(InputController inputController, PlayerView playerView)
    {
        _inputController = inputController;
        _playerView = playerView;
        _inputController.OnDirectionChange += _playerView.SetDirection;
    }


    public void Destroy()
    {
        _inputController.OnDirectionChange -= _playerView.SetDirection;
    }

}
