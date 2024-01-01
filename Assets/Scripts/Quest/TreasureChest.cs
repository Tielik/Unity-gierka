using UnityEngine;
using UnityEngine.InputSystem;
using RPG.Utility;

namespace RPG.Quest{
    public class TreasureChest : MonoBehaviour
    {
        public Animator animatorCmp;
        private bool IsInteractive = false;
        private bool hasBeenOpened = false;
        private void OnTriggerEnter() {
            IsInteractive = true;

        }
        private void OnTriggerExit()
        {
            IsInteractive = false;
        }
        public void HandleInteract(InputAction.CallbackContext context)
        {
            if (!IsInteractive || hasBeenOpened) 
            {
                return;
            }
            animatorCmp.SetBool(Constants.IS_SHAKING_TAG,false);
            hasBeenOpened = true;
        }
    
    
    
    
    }

}
