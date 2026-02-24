using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public class InputService : MonoBehaviour
    {
        public InputActions InputActionsSystem { get; private set; }

        private void Awake()
        {
            InputActionsSystem = new InputActions();
            InputActionsSystem.Enable();

            Debug.Log("[InputService] Service started!");
        }
    }
}