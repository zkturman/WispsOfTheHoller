using UnityEngine;

public class WispBehaviour : MonoBehaviour
{
    private WispManager _manager;

    public void Initialise(WispManager manager)
    {
        _manager = manager;
    }

    public void Collect()
    {
        this.gameObject.SetActive(false);
        _manager.MarkCollected(this);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
