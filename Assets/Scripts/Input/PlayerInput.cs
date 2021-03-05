using UnityEngine;

public class PlayerInput : ITankInput
{
    public float Movement { get; private set; }
    public float Rotation { get; private set; }
    private bool _fireWeapon;
    private bool _swapWeaponsUp;
    private bool _swapWeaponsDown;
    private bool _pauseGame;
    
    public void ReadInput()
    {
        Rotation = Input.GetAxis("Horizontal");
        Movement = Input.GetAxis("Vertical");

        _fireWeapon = Input.GetKeyDown(KeyCode.X);
        if (_fireWeapon)
            EventBroker.CallFireWeapon();
            
        _swapWeaponsUp = Input.GetKeyDown(KeyCode.W);
        if (_swapWeaponsUp)
            EventBroker.CallSwitchWeaponsUp();

        _swapWeaponsDown = Input.GetKeyDown(KeyCode.Q);
        if(_swapWeaponsDown)
            EventBroker.CallSwitchWeaponsDown();
    }

}
