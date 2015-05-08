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
        bool GetCollision();
    }
    interface IInteractive : IBlock
    {
        void Action();
    }


    interface IContainer : IInteractive
    {
        List<Object> GetContent();
    }
    interface IInformational : IInteractive
    {
        string GetMessage();
    }
    interface IEnvironment : IInteractive
    {
        void EnvChange();
    }
}
