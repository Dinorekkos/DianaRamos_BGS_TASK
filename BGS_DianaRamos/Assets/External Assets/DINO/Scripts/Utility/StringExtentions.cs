//Last Update
//Dino 2024/05/10 
//Change class name
namespace DINO.Utility
{
    public static class StringExtension
    {
        public static string SetColor(this string inputText, string color)
        {
            return "<color=" + color + ">" + inputText + "</color>";
        }

    }
}