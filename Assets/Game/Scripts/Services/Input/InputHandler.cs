using System;
using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public class InputHandler : MonoBehaviour
    {
        public Action<Vector2> Move;

        [SerializeField] private InputService _inputService;

        private void Awake()
        {
            Init();
        }

        private void Init() // В данном случае можно сделать через FOOT. Обычно инит делается иначе
        {
            if (_inputService == null)
                _inputService = FindObjectOfType<InputService>();
        }

        public void OnMove()
        {
            Vector2 movementDirection = _inputService.InputActionsSystem.Player.Run.ReadValue<Vector2>();

            Move?.Invoke(movementDirection);

            Debug.Log(movementDirection);
        }

        private void Update()
        {
            OnMove();
        }
    }
}