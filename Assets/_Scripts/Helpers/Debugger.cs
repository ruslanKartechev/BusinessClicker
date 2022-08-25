using UnityEngine;
namespace RuslanScripts
{
    public class Debugger
    {
        public static void LogBlue(string message)
        {
            Debug.Log("<color=blue> " + message + "</color>");
        }

        public static void LogRed(string message)
        {
            Debug.Log("<color=red> " + message + "</color>");

        }
        public static void LogGreen(string message)
        {
            Debug.Log("<color=green> " + message + "</color>");
        }

        public static void LogYellow(string message)
        {
            Debug.Log("<color=yellow> " + message + "</color>");
        }

        public static void LogException(System.Exception ex)
        {
            LogRed($"CAUGHT: {ex.Message}\n{ex.StackTrace}");
        }

        public static void LogError(string message)
        {
            LogRed($"ERROR: {message}");
        }
    }

}
