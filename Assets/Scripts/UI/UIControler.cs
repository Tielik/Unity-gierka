using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UIElements;



namespace RPG.UI
{
    public class UIControler : MonoBehaviour
    {
        private UIDocument uiDocumentCmp;
        public VisualElement root;
        public List<Button> buttons;

        public UIBaseState currentState;
        public UIMainMenuState mainMenuState;
        // Start is called before the first frame update
        public int currentSelection=0;
        private void Awake()
        {
            mainMenuState = new UIMainMenuState(this);

            uiDocumentCmp = GetComponent<UIDocument>();
            root = uiDocumentCmp.rootVisualElement;
        }
        void Start()
        {
            currentState = mainMenuState;
            currentState.EnterState();
        }
        public void HandleInteract(InputAction.CallbackContext context) 
        {
            if (!context.performed) return;
            currentState.SelectButton();

        }
        public void HandleNavigate(InputAction.CallbackContext context)
        {
            if (!context.performed|| buttons.Count==0) return;

            buttons[currentSelection].RemoveFromClassList("active");

            Vector2 input=context.ReadValue<Vector2>();
            currentSelection += input.x > 0 ? 1:-1;
            currentSelection = Mathf.Clamp(currentSelection,0,buttons.Count-1);
            buttons[currentSelection].AddToClassList("active");
        }
    }

}