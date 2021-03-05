using UnityEngine;
using Pathfinding;

public class EnemyControllerBasic : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float turnSpeed = 5f;
    private float _nextWaypointDistance = 3f;
    private Transform _target;

    private Path _path;
    private int _currentWaypoint = 0;
    private bool _reachedEndOfPath;

    private Seeker _seeker;
    private Rigidbody2D _rb;

    private void Awake()
    {
        EventBroker.StartEnemyTankHandler += StartEnemyTank;
    }

    private void StartEnemyTank()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
    }

    private void UpdatePath()
    {
        if(_seeker.IsDone())
            _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
        
    }

    //Generating path
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        //Checking if reached end of path
        if (_path == null) return;

        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            _reachedEndOfPath = true;
            return;
        }
        else
        {
            _reachedEndOfPath = false;
        }
        
        Move();

        //calculating distance
        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);
        if (distance < _nextWaypointDistance)
        {
            _currentWaypoint++;
        }
        
        Rotate();
    }

    private void Move()
    {
        var position = _rb.position;
        Vector2 direction = ((Vector2) _path.vectorPath[_currentWaypoint] - position).normalized;
        _rb.MovePosition(position + direction * (speed * Time.fixedDeltaTime));
    }

    private void Rotate()
    {
        if (_currentWaypoint > _path.vectorPath.Count - 1) return;
        Vector2 vectorToTarget = _path.vectorPath[_currentWaypoint] - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        _rb.MoveRotation(Mathf.LerpAngle(_rb.rotation,angle ,turnSpeed * Time.deltaTime));
    }

    private void OnDestroy()
    {
        EventBroker.StartEnemyTankHandler -= StartEnemyTank;
    }
}
