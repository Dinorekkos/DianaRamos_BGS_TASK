using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D[] _cursorsTexture;
    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;

    private int _currentFrame;
    private float _frameTimer;
    
    void Start()
    {
        Cursor.SetCursor(_cursorsTexture[0], Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        _frameTimer -= Time.deltaTime;
        if (_frameTimer <= 0)
        {
            _frameTimer += frameRate;
            _currentFrame = (_currentFrame + 1) % frameCount;
            Cursor.SetCursor(_cursorsTexture[_currentFrame], Vector2.zero, CursorMode.Auto);
        }
    }
}
