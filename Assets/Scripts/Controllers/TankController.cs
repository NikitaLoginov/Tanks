using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private TankSettings tankSettings;
    private Rigidbody2D _tankRb;
    private ITankInput _tankInput;
    private TankEngine _tankEngine;

    private void Awake()
    {
        _tankInput = new PlayerInput();
        _tankRb = GetComponent<Rigidbody2D>();

        _tankEngine = new TankEngine(_tankInput, transform, _tankRb,tankSettings);
    }

    private void Update()
    {
        _tankInput.ReadInput();
    }

    private void FixedUpdate()
    {
        _tankEngine.Tick();
    }
}
