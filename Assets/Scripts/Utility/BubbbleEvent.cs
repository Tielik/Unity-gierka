using UnityEngine;
using UnityEngine.Events;
namespace RPG.Utility
{
    public class BubbbleEvent : MonoBehaviour
    {
        public event UnityAction OnBubbleStartAttack=()=> { };
        public event UnityAction OnBubbleCompleteAttack=()=> { };
        public event UnityAction OnBubbleOnHit = () => { };
        public event UnityAction OnBubbleCompleteDefeat=()=> { };
        private void OnStartAttack()
        {
            print("asdasdfsad");
            OnBubbleStartAttack.Invoke();
        }
        private void OnCompleteAttack()
        {
            OnBubbleCompleteAttack.Invoke();
        }
        private void OnHit()
        {
            OnBubbleOnHit.Invoke();
        }
        private void OnCompleteDefeat()
        {
            OnBubbleCompleteDefeat.Invoke();
        }
    }
}
