using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using Mono.TextTemplating;

namespace shaderLabLab
{
    public static class SLLUtils
    {
        private static string getFullFilePath(string assetFilePath)
        {
            return Application.dataPath + assetFilePath.Substring(6);  // Removing 'Assets' from start of path            
        }

        private static string getFullShaderPathFromTempatePath(string templatePath)
        {
            return templatePath.Substring(0, templatePath.Length - 3);
        }

        public static void generateShader(string templateFile)
        {
            string inPath = getFullFilePath(templateFile);
            string outPath = getFullShaderPathFromTempatePath(inPath);
            string outAssetPath = templateFile.Substring(0, templateFile.Length - 3);
            TemplateGenerator generator = new TemplateGenerator();
            
            Debug.Log(outPath);
            try
            {
                bool seccuess = generator.ProcessTemplate(inPath, outPath);
                if(!seccuess)
                {
                    Debug.LogError("ShaderLabLab failed to pass tempate: " + inPath);
                    Debug.LogError("ShaderLabLab:" + generator.Errors);
                    return;
                }

                AssetDatabase.ImportAsset(outAssetPath, ImportAssetOptions.Default);
                //AssetDatabase.Refresh();
            }
            catch(Exception e)
            {                
                Debug.LogError("ShaderLabLab: Error passing sahder template.  In: " + inPath + ", Out: " + outPath);
                Debug.LogError("ShaderLabLab:" + e.Message);
            }            
        }
    }
}
