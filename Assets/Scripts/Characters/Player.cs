
public class Player : Character
{
    protected override void Die()
    {
        base.Die();
        EventBroker.CallGameOver();
    }
}
