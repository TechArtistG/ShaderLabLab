using UnityEngine;
using UnityEditor;

namespace shaderLabLab
{
    public class ShaderLabLabProcessor : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath)
        {
            foreach (string asset in importedAssets)
            {                
                if (asset.EndsWith(".shader.tt")) SLLUtils.generateShader(asset);
            }

            foreach (string asset in deletedAssets)
            {
                Debug.Log("Deleted: " + asset);
            }

            for (int i = 0; i < movedAssets.Length; i++)
            {
                Debug.Log("Moved: from " + movedFromPath[i] + " to " + movedAssets[i]);
            }
        }
    }
}

