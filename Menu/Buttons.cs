using BreezeV2.Classes;
using BreezeV2.Mods;
using static BreezeV2.Menu.Main;
using static BreezeV2.Settings;



namespace BreezeV2.Menu
{
    public class Buttons
    {
        /*
         * Here is where all of your buttons are located.
         * To create a button, you may use the following code:
         * 
         * Move to Category:
         *   new ButtonInfo { buttonText = "Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Opens the main settings page for the menu."},
         *   new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
         * 
         * Togglable Mod:
         *   new ButtonInfo { buttonText = "Platforms", method =() => Movement.Platforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
         */

        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods [0]
                new ButtonInfo { buttonText = "Settings", method = () => currentCategory = 1, isTogglable = false, toolTip = "Opens the main settings page for the menu." },
                new ButtonInfo { buttonText = "Room Mods", method = () => currentCategory = 4, isTogglable = false, toolTip = "Opens the room mods tab." },
                new ButtonInfo { buttonText = "Movement Mods", method = () => currentCategory = 5, isTogglable = false, toolTip = "Opens the movement mods tab." },
                new ButtonInfo { buttonText = "Safety Mods", method = () => currentCategory = 6, isTogglable = false, toolTip = "Opens the safety mods tab." },
                new ButtonInfo { buttonText = "Advantage Mods", method = () => currentCategory = 7, isTogglable = false, toolTip = "Opens the advantage mods tab." },
                new ButtonInfo { buttonText = "Overpowered Mods", method = () => currentCategory = 8, isTogglable = false, toolTip = "Opens the Overpowered mods tab." },
                new ButtonInfo { buttonText = "Debug", method = () => currentCategory = 9, isTogglable = false, toolTip = "Temporary mods" },
                new ButtonInfo { buttonText = "Visual Mods", method = () => currentCategory = 11, isTogglable = false, toolTip = "Toggles visual mods." },
                new ButtonInfo { buttonText = "Other", method = () => currentCategory = 10, isTogglable = false, toolTip = "Mods that are to niche to have a catagory" }
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return to Main", method = () => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu." },
                new ButtonInfo { buttonText = "Menu", method = () => currentCategory = 2, isTogglable = false, toolTip = "Opens the settings for the menu." },
                new ButtonInfo { buttonText = "Movement", method = () => currentCategory = 3, isTogglable = false, toolTip = "Opens the movement settings for the menu." },
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method = () => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu." },
                new ButtonInfo { buttonText = "darktext", enableMethod = () => Darktext = true, disableMethod = () => Darktext = false, isTogglable = true, toolTip = "changes text color to black" },
                new ButtonInfo { buttonText = "Right Hand", enableMethod = () => rightHanded = true, disableMethod = () => rightHanded = false, toolTip = "Puts the menu on your right hand." },
                new ButtonInfo { buttonText = "Notifications", enableMethod = () => disableNotifications = false, disableMethod = () => disableNotifications = true, enabled = !disableNotifications, toolTip = "Toggles the notifications." },
                new ButtonInfo { buttonText = "FPS Counter", enableMethod = () => fpsCounter = true, disableMethod = () => fpsCounter = false, enabled = fpsCounter, toolTip = "Toggles the FPS counter." },
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod = () => disconnectButton = true, disableMethod = () => disconnectButton = false, enabled = disconnectButton, toolTip = "Toggles the disconnect button." },
                new ButtonInfo { buttonText = "Leave after 7 reports", enableMethod = () => Safety.Leaveafter7reports = true, disableMethod = () => Safety.Leaveafter7reports = false, isTogglable = true, toolTip = "changes text color to black", enabled = true },
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Return to Settings", method = () => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu." },

                new ButtonInfo { buttonText = "Change Fly Speed", overlapText = "Change Fly Speed [Normal]", method = () => Mods.Settings.Movement.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes the speed of the fly mod." },
            },

            new ButtonInfo[] { // Room Mods [4]
                new ButtonInfo { buttonText = "Return to Main", method = () => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu." },
            #region <----Codes----->
                new ButtonInfo { buttonText = "Disconnect", method = () => NetworkSystem.Instance.ReturnToSinglePlayer(), isTogglable = false, toolTip = "Disconnects you from the room." },
                new ButtonInfo { buttonText = "Join Code Mod", method = () => RoomMods.Joinroom("MOD"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Mods", method = () => RoomMods.Joinroom("MODS"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Lucio", method = () => RoomMods.Joinroom("LUCIO"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Furry", method = () => RoomMods.Joinroom("FURRY"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Gay", method = () => RoomMods.Joinroom("GAY"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Pugs", method = () => RoomMods.Joinroom("PUGS"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Menu Room", method = () => RoomMods.Joinroom("breezeV2"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Cat", method = () => RoomMods.Joinroom("CAT"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Kitty", method = () => RoomMods.Joinroom("KITTY"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code IIDK", method = () => RoomMods.Joinroom("IIDK"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Twig", method = () => RoomMods.Joinroom("TWIG"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Twigcore", method = () => RoomMods.Joinroom("TWIGCORE"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Sren17", method = () => RoomMods.Joinroom("SREN17"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code Sren18", method = () => RoomMods.Joinroom("SREN18"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code PBBV", method = () => RoomMods.Joinroom("PBBV"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code J3VU", method = () => RoomMods.Joinroom("J3VU"), isTogglable = false, toolTip = "Self explanatory" },
                new ButtonInfo { buttonText = "Join Code RUN", method = () => RoomMods.Joinroom("RUN"), isTogglable = false, toolTip = "Self explanatory" },

#endregion  
            },

            new ButtonInfo[] { // Movement Mods [5]
                new ButtonInfo { buttonText = "Return to Main", method = () => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu." },

                new ButtonInfo { buttonText = "Platforms", method = () => Movement.Platforms(), toolTip = "Spawns platforms on your hands when pressing grip." },
                new ButtonInfo { buttonText = "Fly", method = () => Movement.Fly(), toolTip = "Sends you forward when holding A." },
                new ButtonInfo { buttonText = "Teleport Gun", method = () => Movement.TeleportGun(), toolTip = "Teleports you to wherever your pointer is when pressing trigger." },
                new ButtonInfo { buttonText = "Quest Slide control", enableMethod = () => Movement.SlideControl(0.06777f), toolTip = "Ice controls as if you are a quest player" },
                new ButtonInfo { buttonText = "Better slide control", enableMethod = () => Movement.SlideControl(0.9f), toolTip = "Ts is to much" },
                new ButtonInfo { buttonText = "To much slide control", enableMethod = () => Movement.SlideControl(2f), toolTip = "Why whould you want this" }, // hey so like im really bored and am running out of ideas for mods. if you have any ideas please dm me >: )
            },

            new ButtonInfo[] { // Safety Mods [6]
                new ButtonInfo { buttonText = "Return to Main", method = () => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu." },

                new ButtonInfo { buttonText = "Return to Stump [B]", method = () => Safety.ReturnToStump(), toolTip = "Teleports you back to stump when pressing B." },
                new ButtonInfo { buttonText = "Disconnect [LT]", method = () => Safety.LTdisconnect(), isTogglable = true, toolTip = "Press Left trigger 2 disconnect" },
                new ButtonInfo { buttonText = "Anti Handlink", method = () => Safety.Antihandlink(), toolTip = "Prevents handlinking by Rejecting handlink requests." },
                new ButtonInfo { buttonText = "Report counter", method = () => Safety.AntiReport(), toolTip = "It counts how many times you have been reported (Experimental)", disableMethod = () => Safety.reportcount =0},
            },

            new ButtonInfo[] { // Advantage Mods [7]
                new ButtonInfo { buttonText = "Return to Main", method = () => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu." },

                new ButtonInfo { buttonText = "notify when lavas near", method = () => Advantage.NotifyWhenLavaIsNear(), toolTip = "Notifys you when lava is near." },


            },
            new ButtonInfo[] { // Overpowered Mods [8]
                new ButtonInfo { buttonText = "Return to Main", method = () => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu." },

                new ButtonInfo { buttonText = "Fling player [X]", method = () => Overpowered.Fling(), toolTip = "flings players when pressing X (Mustbehandlinked)" },
                new ButtonInfo { buttonText = "Random Teleport [X]", method = () => Overpowered.RandomTpPlayer(), toolTip = "Teleports players randomly when pressing X (Must be handlinked)" },


            },
            new ButtonInfo[] { // Debug Mods [9]
                new ButtonInfo { buttonText = "Return to Main", method = () => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu." },
                new ButtonInfo { buttonText = "wasdFly", method = () => Temp.WASDFly(), toolTip = "T" },
            },
            new ButtonInfo[] { // Other [10]
                new ButtonInfo { buttonText = "Return to Main", method = () => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu." },
                new ButtonInfo { buttonText = "BuildGun", method = () => Otherstuff.Buildgun(), toolTip = "Spawns a gun that can place cubes" },
                new ButtonInfo { buttonText = "Destroy Gun", method = () => Otherstuff.DestroyGun(), toolTip = "Spawns a gun that can destroy ANYTHING"},
                new ButtonInfo { buttonText = "gunlibfix", method = () => Otherstuff.GunLibfix(), toolTip = "i fucking hate iitemp", enabled = true}
            },
            new ButtonInfo[] { //visual Mods [11]
                new ButtonInfo { buttonText = "Return to Main", method = () => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu." },
                new ButtonInfo { buttonText = "Babyboo ESP", method = () => Visual.Esp(), isTogglable = true, toolTip="shegoncallmeboxesp"}
                
            }
        };
    }
}
