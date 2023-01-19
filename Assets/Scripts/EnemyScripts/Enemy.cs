using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private int _score;
    public int Score
    {
        get => _score;
        set => _score = value;
    }
}
