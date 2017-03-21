using System;

namespace BIMWebService.Mode.Sys
{
    [Serializable]
    public enum BoItemTreeTypes
    {
        iNotATree = 0,
        iAssemblyTree = 1,
        iSalesTree = 2,
        iProductionTree = 3,
        iTemplateTree = 4,
        iIngredient = 5
    }
}