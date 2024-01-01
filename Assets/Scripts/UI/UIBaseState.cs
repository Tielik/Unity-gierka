using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.UI
{
    public abstract class UIBaseState
    {
        public UIControler controler;

        public UIBaseState(UIControler ui)
        {
            controler = ui;
        }
        public abstract void EnterState();
        public abstract void SelectButton();
    }

}
