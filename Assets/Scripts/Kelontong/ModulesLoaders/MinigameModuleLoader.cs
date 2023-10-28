using System.Collections;
using System.Collections.Generic;
using Arr.MiscModules;
using Arr.ModulesSystem;
using UnityEngine;

public class MinigameModuleLoader : ModulesLoader
{
    protected override BaseModule[] Modules => new BaseModule[]
    {
        new UnityEventSystemModule()
    };
}
