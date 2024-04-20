using System.IO;
using UnityEngine;
using UnityEngine.UI;
using XLua;

namespace EmmyLua
{
    [LuaCallCSharp]
    public static class UnityExtensionMethods
    {
        
        public static string GetTextAsset(string path)
        {
            
            
            return Resources.Load<TextAsset>(path).text;
            
        }
        
        public static Button GetButton(this GameObject go)
        {
            return go.GetComponent<Button>();
        }

        public static string ReadFileText(string path)
        {
            string rootPath = Application.dataPath;
            string content = File.ReadAllText(Path.Combine(rootPath,"Resources",path));
            return content;
        }
    }
}