using UnityEngine;

namespace RPG.Character
{
    public class AIPatrolState : AIBaseState
    {
        public override void EnterState(EnemyController enemy)
        {
            enemy.patrolCmp.ResetTimers();
        }

        public override void UpdateState(EnemyController enemy)
        {
            if (enemy.distanceFromPlayer < enemy.chaseRange)
            {
                enemy.SwitchState(enemy.chaseState);
                return;
            }
            Vector3 oldPosition=enemy.patrolCmp.GetNextPosition();

            enemy.patrolCmp.CalculateNextPosition();

            Vector3 currentPosition = enemy.transform.position;
            Vector3 newPosition = enemy.patrolCmp.GetNextPosition();
            Vector3 offset = newPosition - currentPosition;
            Vector3 fatherOutPosition=enemy.patrolCmp.GetFatherOutPosition();
            enemy.movementCmp.MoveAgentByOffset(offset);
            Vector3 newForwardVector = fatherOutPosition - currentPosition;
            newForwardVector.y = 0;

            enemy.movementCmp.Rotate(newForwardVector);
            if(oldPosition == newPosition)
            {
                enemy.movementCmp.isMoving = false;
            }
        }
    }
}