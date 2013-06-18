using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public enum GameState
    {
        Play = -1,
        Pause = 1
    }

    public enum GamemodeState
    { 
        Stan,
        Easy,
        Medium,
        Hard,
        Abe,
        Multiplayer,
        SinglePlayer,
        Gun
    }

    public enum ScreenState
    { 
       TitleScreen,
       SinglePlayer,
       MultiPlayer,
       Options
    }
}
