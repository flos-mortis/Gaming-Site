using System;
using System.Collections.Generic;

#nullable disable

namespace Playstore
{
    public partial class PlatformGame
    {
        public int PlatformId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
