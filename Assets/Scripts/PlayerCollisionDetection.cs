using System;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    private Player _player;
    private float _timeUntilNextHit = 1f;
    private float _nextHitTime;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        
        var enemy = other.gameObject.GetComponent<Enemy>();
        _player.TakeDamage(enemy.damage);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Enemy") || !CanHit()) return;
        var enemy = other.gameObject.GetComponent<Enemy>();
        _player.TakeDamage(enemy.damage);
        _nextHitTime = Time.time + _timeUntilNextHit;
    }

    private bool CanHit()
    {
        return Time.time >= _nextHitTime;
    }
}
