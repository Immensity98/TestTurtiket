using Game.Scripts.Data;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.Services.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(InputHandler))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private InputHandler _inputHandler;

        private float _currentSpeed;
        private Vector2 _direction;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _inputHandler.Move += OnMove;
        }

        private void
            Init() // Обычно Input - глобальный сервис и не висит на игроке. В данном случае можно пренебречь и использовать GC для инициализации
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _inputHandler = GetComponent<InputHandler>();
            if (_playerData == null)
                _playerData = Resources.Load<PlayerData>("Data/Player/PlayerData");
        }

        private void OnMove(Vector2 direction)
        {
            _direction = direction;
        }

        public void Move()
        {
            float targetSpeed = _direction.x * _playerData.MaxSpeed;
            float accel = Mathf.Abs(_direction.x) > 0.01f ? _playerData.Acceleration : _playerData.Deceleration;

            _currentSpeed = Mathf.MoveTowards(_currentSpeed, targetSpeed, accel * Time.fixedDeltaTime);
            _rigidbody2D.velocity = new Vector2(_currentSpeed, _rigidbody2D.velocity.y);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnDestroy()
        {
            _inputHandler.Move -= OnMove;
        }
    }
}