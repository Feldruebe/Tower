using UnityEngine;
using System.Collections;

public static class LayerHelper {

    public static LayerMask GetLayerMaskByName(params string[] layers)
    {
        LayerMask returnLayer = new LayerMask();
        foreach (var layerName in layers)
        {
            returnLayer = ((int)returnLayer) | (1 << LayerMask.NameToLayer(layerName));
        }

        return returnLayer;
    }
}