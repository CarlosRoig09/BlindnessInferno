using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaivour : MovingPlatform
{
    private Collider2D _collider2D;
    void IncrementLongitude(float newSizeY)
    {
        transform.localScale = new Vector3(transform.localScale.x,newSizeY, transform.localScale.z);
        _collider2D.transform.localScale = new Vector3(transform.localScale.x, newSizeY, transform.localScale.z);
    }
}
