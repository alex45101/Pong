using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class StateManager
    {
        public static GameState gameState { get; set;}
        public static GamemodeState gamemodestate { get; set; }
        public static ScreenState screenstate { get; set; }
    }
}
