using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNETv3
{
    class PlayerContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Audio> Audios { get; set; }

    }
}
