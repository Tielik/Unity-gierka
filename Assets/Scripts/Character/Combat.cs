using System;
using UnityEngine;
using UnityEngine.InputSystem;
using RPG.Utility;

namespace RPG.Character
{
    public class Combat : MonoBehaviour
    {
        [NonSerialized] public float damage = 0f;
        [NonSerialized] public bool isAttacking = false;

        private Animator animatorCmp;
        private BubbbleEvent bubbbleEventCMP;
        private void Awake()
        {
            animatorCmp = GetComponentInChildren<Animator>();
            bubbbleEventCMP = GetComponentInChildren<BubbbleEvent>();
        }
        private void OnEnable()
        {
            bubbbleEventCMP.OnBubbleStartAttack += HandleBubbleStartAttack;
            bubbbleEventCMP.OnBubbleCompleteAttack += HandleBubbleCompleteAttack;
            bubbbleEventCMP.OnBubbleOnHit +=HandleBubbleOnHit;
            
        }

        private void OnDisable()
        {
            bubbbleEventCMP.OnBubbleStartAttack -= HandleBubbleStartAttack;
            bubbbleEventCMP.OnBubbleCompleteAttack -= HandleBubbleCompleteAttack;
            bubbbleEventCMP.OnBubbleOnHit -= HandleBubbleOnHit;

        }
        public void HandleAttack(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            StartAttack();
        }
        public void StartAttack()
        {
            if (isAttacking) return;
            animatorCmp.SetFloat(Constants.ATTACK_ANIMATOR_PARAM,0);
            animatorCmp.SetTrigger(Constants.ATTACK_ANIMATOR_PARAM);
        }
        private void HandleBubbleStartAttack()
        {
            isAttacking = true;
        }
        private void HandleBubbleCompleteAttack()
        {
            isAttacking = false;
        }

        private void HandleBubbleOnHit()
        {
            RaycastHit[] targets= Physics.BoxCastAll(
                transform.position+transform.forward,
                transform.localScale/2,
                transform.forward,
                transform.rotation,
                1f
                );
            foreach (RaycastHit target in targets)
            {
                if (CompareTag(target.transform.tag)) continue;
                Health healthCmp=target.transform.gameObject.GetComponent<Health>();
                if (healthCmp == null) continue;
                healthCmp.TakeDamage(damage);
            }
        }
        public void CancelAttack()
        {
            animatorCmp.ResetTrigger(Constants.ATTACK_ANIMATOR_PARAM);
        }
    }
}