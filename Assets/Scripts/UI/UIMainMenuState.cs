using UnityEngine.UIElements;
using UnityEngine;
using RPG.Core;

namespace RPG.UI
{
    public class UIMainMenuState : UIBaseState
    {
        public UIMainMenuState(UIControler ui): base(ui)
        {
            
        }
        public override void EnterState()
        {
            controler.buttons = controler.root.Query<Button>(null,"menu-button").ToList();
            Debug.Log(controler.buttons.Count);
            controler.buttons[0].AddToClassList("active");
        }

        public override void SelectButton()
        {
            Button btn = controler.buttons[controler.currentSelection];
            if(btn.name=="start-button") 
            {
                SceneTransition.Initiate(1);
            }
        }


    }

}
