using System.Collections;
using System.Collections.Generic;
using Arr.MiscModules;
using Arr.ModulesSystem;
using Kelontong.Modules;
using Kelontong.Modules.ViewModules;
using UnityEngine;

public class TestingModuleLoader : ModulesLoader
{
    protected override BaseModule[] Modules => new BaseModule[]
    {
        new UnityEventSystemModule(),
        new CalculatorViewModule(),
    };
}
