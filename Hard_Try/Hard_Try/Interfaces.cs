using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    interface IBlock
    {
        void LightChange();
        string GetDescription();
    }
    interface IInteractive
    {
        void ChangeState();
    }




    interface ILootable : IBlock
    {
        void ShowContent();
        List<Object> GetContent();
    }
    interface IInformational : IInteractive
    {
        void ShowMessage();
    }
    interface ISwitchable : IBlock, IInteractive
    {
        void Action();
    }
    interface IEnvironment : IInteractive
    {
        void EnvChange();
    }
}
