using System;
using UnityEngine;
using RPG.Utility;
using UnityEngine.Events;
namespace RPG.Character
{
    public class Health : MonoBehaviour
    {
        public event UnityAction OnStartDefeated=()=> { };
        [NonSerialized] public float healthPoints = 0f;

        private Animator animatorCmp;
        private BubbbleEvent bubbleEventCmp;
        private bool isDefeated = false;

        private void Awake()
        {
            animatorCmp = GetComponentInChildren<Animator>();
            bubbleEventCmp = GetComponentInChildren<BubbbleEvent>();
        }
        private void OnEnable()
        {
            bubbleEventCmp.OnBubbleCompleteDefeat += HandleBubbleCompleteDefeat;
        }
        private void OnDisable()
        {
            bubbleEventCmp.OnBubbleCompleteDefeat -= HandleBubbleCompleteDefeat;
        }

        public void TakeDamage(float damageAmount)
        {
            print(healthPoints);
            healthPoints = Mathf.Max(healthPoints-damageAmount,0);
            if (healthPoints <= 0f)
            {
                defeated();
            }
        }
        private void defeated()
        {
            if (isDefeated) return;
            if (CompareTag(Constants.ENEMY_TAG)) { OnStartDefeated.Invoke();  }
            isDefeated=true;
            animatorCmp.SetTrigger(Constants.DEFEATED_ANIMATOR_PARAM);
        }
        private void HandleBubbleCompleteDefeat()
        {
            Destroy(gameObject);
        }
    }

}