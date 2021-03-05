using System;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Camera _camera;
    private Vector2 _screenBounds;
    private float _objectWidth;
    private float _objectHeight;

    private void Awake()
    {
        _camera = Camera.main;

        if (!(_camera is null))
        {
            _screenBounds =_camera.ScreenToWorldPoint(
                new Vector3(Screen.width, Screen.height, _camera.transform.position.z));
        }


        var bounds = GetComponent<BoxCollider2D>().bounds;
        _objectWidth = bounds.size.x / 2;
        _objectHeight = bounds.size.y / 2;
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -_screenBounds.x + _objectWidth, _screenBounds.x - _objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -_screenBounds.y + _objectHeight, _screenBounds.y - _objectHeight);
        transform.position = viewPos;
    }
}
