using UnityEngine;

public class DetectGround : MonoBehaviour
{
    private int _ignoreLayer = 6;

    public delegate void IsGround(bool isGround);
    public event IsGround IsGroundCallback;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != _ignoreLayer)
        {
            IsGroundCallback.Invoke(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != _ignoreLayer)
        {
            IsGroundCallback.Invoke(false);
        }
    }
}