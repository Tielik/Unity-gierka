using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
namespace RPG.Character
{
    public class Movement : MonoBehaviour
    {
        static public Vector3 movementVector;
        static private NavMeshAgent agent;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        public void HandleMove(InputAction.CallbackContext context)
        {
            print(movementVector);
            Vector2 input = context.ReadValue<Vector2>();
            movementVector = new Vector3(input.x, 0, input.y);
        }
        public void MovePlayer(Vector3 X)
        {
            agent.Move(X);
        }

        public void Update()
        {
            print(movementVector);
            if (movementVector!=Vector3.zero)
            {
                MovePlayer(movementVector);
            }
        }
    }
}
