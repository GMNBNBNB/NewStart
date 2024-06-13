using Cinemachine;
using UnityEngine;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundingShape();
    }

    /// <summary>
    /// switch the collider that cinemachine uses to define the edges of the screen
    /// </summary>

    private void SwitchBoundingShape()
    {
        PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();

        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();

        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

        // changed, so call this clear the cache

        cinemachineConfiner.InvalidatePathCache();
    }


}
