using System.Collections;
using System.Collections.Generic;
using Arr.ModulesSystem;
using Kelontong.Modules;
using UnityEngine;

public class TestPlayerModuleLoader : ModulesLoader
{
    protected override BaseModule[] Modules => new[]
    {
        new PlayerControllerModule()
    };

}
