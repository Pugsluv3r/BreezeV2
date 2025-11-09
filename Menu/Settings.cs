using BreezeV2.Classes;
using UnityEngine;

namespace BreezeV2
{
    public class Settings
    {
        /*
         * These are the settings for the menu.
         * 
         * To change the colors, you need to modify the ExtGradient variables.
         * Here are some examples on how to use ExtGradient:
         * 
         * Solid Color:
         *  new ExtGradient { colors = ExtGradient.GetSolidGradient(Color.black) }
         *  
         * Simple Gradient:
         *  new ExtGradient { colors = ExtGradient.GetSimpleGradient(Color.black, Color.white) }
         * 
         * Rainbow Color:
         *   new ExtGradient { rainbow = true }
         *   
         * Epileptic Color (random color every frame):
         *   new ExtGradient { epileptic = true }
         *   
         * Self Color:
         *   new ExtGradient { copyRigColor = true }
         *   
         * To change the font, you may use the following code:
         *   Font.CreateDynamicFontFromOSFont("Comic Sans MS", 24)
         */

        public static ExtGradient backgroundColor = new ExtGradient { colors = ExtGradient.GetSolidGradient(new Color(145f / 255f, 185f / 255f, 237f / 255f)) };
        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
                new ExtGradient { colors = ExtGradient.GetSolidGradient(Color.turquoise) }, // Disabled
                new ExtGradient { colors = ExtGradient.GetSolidGradient(Color.lightBlue) }  // Enabled
        };

        public static bool Darktext = false;

        
        public static Color[] textColors => Darktext
            ? new[] { Color.black, Color.black }   // Disabled, Enabled when dark text is enabled
            : new[] { Color.white, Color.white };  // Disabled, Enabled when dark text is disabled

        public static Font currentFont = Font.CreateDynamicFontFromOSFont("Comic Sans MS", 24);

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded;
        public static bool disableNotifications;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1f); // Depth, width, height
        public static int buttonsPerPage = 8;

        public static float gradientSpeed = 0; // Speed of colors
    }
}
