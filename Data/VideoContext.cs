using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoAPI.Models;

namespace VideoAPI.Data
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> opts) : base(opts)
        {

        }

        public DbSet<Video> Videos { get; set; }
    }
}
