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
                new ButtonInfo { buttonText = "Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Opens the main settings page for the menu."},

                new ButtonInfo { buttonText = "Room Mods", method =() => currentCategory = 4, isTogglable = false, toolTip = "Opens the room mods tab."},
                new ButtonInfo { buttonText = "Movement Mods", method =() => currentCategory = 5, isTogglable = false, toolTip = "Opens the movement mods tab."},
                new ButtonInfo { buttonText = "Safety Mods", method =() => currentCategory = 6, isTogglable = false, toolTip = "Opens the safety mods tab."},
                new ButtonInfo { buttonText = "Advantage Mods", method =() => currentCategory = 7, isTogglable = false, toolTip = "Opens the advantage mods tab."},
                new ButtonInfo { buttonText = "Overpowered Mods", method =() => currentCategory = 8, isTogglable = false, toolTip = "Opens the Overpowered mods tab."},
                new ButtonInfo { buttonText = "Debug", method =() => currentCategory = 9, isTogglable = false, toolTip = "Hello "},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => currentCategory = 2, isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => currentCategory = 3, isTogglable = false, toolTip = "Opens the movement settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => rightHanded = true, disableMethod =() => rightHanded = false, toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => disableNotifications = false, disableMethod =() => disableNotifications = true, enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => fpsCounter = true, disableMethod =() => fpsCounter = false, enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => disconnectButton = true, disableMethod =() => disconnectButton = false, enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},

                new ButtonInfo { buttonText = "Change Fly Speed", overlapText = "Change Fly Speed [Normal]", method =() => Mods.Settings.Movement.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes the speed of the fly mod."},
            },

            new ButtonInfo[] { // Room Mods [4]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Disconnect", method =() => NetworkSystem.Instance.ReturnToSinglePlayer(), isTogglable = false, toolTip = "Disconnects you from the room."},
                new ButtonInfo { buttonText = "Join Code Mod", method = () => RoomMods.Joinroommod(), isTogglable = false, toolTip = "Self explanatory"},
                new ButtonInfo { buttonText = "Join Code Mods", method = () => RoomMods.Joinroommods(), isTogglable = false, toolTip = "Self explanatory"},
                new ButtonInfo { buttonText = "Join Code Lucio", method = () => RoomMods.JoinroomLucio(), isTogglable = false, toolTip = "Self explanatory"},
            },

            new ButtonInfo[] { // Movement Mods [5]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Platforms", method =() => Movement.Platforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.Fly(), toolTip = "Sends you forward when holding A."},
                new ButtonInfo { buttonText = "Teleport Gun", method =() => Movement.TeleportGun(), toolTip = "Teleports you to wherever your pointer is when pressing trigger."},
                new ButtonInfo { buttonText = "Low Gravity", enableMethod =() => Movement.Gravitychanger(7.3f), toolTip = "Monkes on teh moon!"},
                new ButtonInfo { buttonText = "Super Low Gravity", enableMethod =() => Movement.Gravitychanger(14f), toolTip = "Monkes in Space!!!"},
                new ButtonInfo { buttonText = "Jupiter Gravity", enableMethod =() => Movement.Gravitychanger(-0.46f), toolTip = "Feel the weight of jupiter silly monke..."}, // hey so like im really bored and am running out of ideas for mods. if you have any ideas please dm me >: )
            },

            new ButtonInfo[] { // Safety Mods [6]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Return to Stump [B]", method =() => Safety.ReturnToStump(), toolTip = "Teleports you back to stump when pressing B."},
                new ButtonInfo { buttonText = "Anti Handlink", method =() => Safety.Antihandlink(), toolTip = "Prevents handlinking by Rejecting handlink requests."},
                new ButtonInfo { buttonText = "Dominant Monke", method =() => Safety.Dominantmonke(), toolTip = "When handlinked you are always dominant >:3 (cant be flinged)."},
            },

            new ButtonInfo[] { // Advantage Mods [7]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                
                new ButtonInfo { buttonText = "notify when lavas near", method =() => Advantage.NotifyWhenLavaIsNear(), toolTip = "Notifys you when lava is near."},
                new ButtonInfo { buttonText = "Tracers (NW)", method =() => Advantage.Tracers(), toolTip = "Shows tracers to players."},
                new ButtonInfo { buttonText = "Remove Flick limit", method =() => Advantage.RemoveFlicklimit(), toolTip = "Removes the flick tag limit."}
            },
            new ButtonInfo[] { // Overpowered Mods [8]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Fling player [X]", method =() => Overpowered.Fling(), toolTip = "flings players when pressing X (Mustbehandlinked)"},
                new ButtonInfo { buttonText = "Random Teleport [X]", method =() => Overpowered.RandomTpPlayer(), toolTip = "Teleports players randomly when pressing X (Must be handlinked)"},
                

            },
            new ButtonInfo[] { // Debug Mods [9]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "wasdFly", method =() => Temp.WASDFly(), toolTip = "WASD fly is made by IIDK/Crimson This is located in Temp.cs becasue it will be removed"},

            },
        };
    }
}
