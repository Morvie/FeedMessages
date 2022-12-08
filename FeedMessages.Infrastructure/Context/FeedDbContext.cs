using FeedMessages.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedMessages.Infrastructure.Context
{
    public class FeedDbContext: DbContext
    {
        public FeedDbContext(DbContextOptions<FeedDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeedDto>().ToTable("feed");
            modelBuilder.Entity<FeedDto>().HasData(
                new FeedDto(Guid.NewGuid(), "Clue (1985)", "Let’s discuss one of my favorite movies of all time: CLUE. It is such a fun film. Based on a board game, six guests arrive at an isolated mansion for dinner, drinks, and MURDER. Starring: Tim Curry, Eileen Brennan, Madeline Kahn, Christopher Lloyd, Michael McKean, Martin Mull, Lesley Ann Warren, Lee Ving, Colleen Camp, and Howard Hesseman.", "boringwhitecollar", DateTime.Now, DateTime.Now),
                new FeedDto(Guid.NewGuid(), "What is the greatest James Bond 007 theme song of all time?", "The James Bond films are known for their original opening themes written by popular artists and are often played on the radio and tv. 'Live and Let Die' by Paul McCartney, 'For Your Eyes Only' by Sheena Easton, 'A View to a Kill' by Duran Duran, and 'Goldfinger' by Shirley Bassey are just a few. My personal favorite is 'Nobody Does It Better' by Carly Simon. What James Bond theme do you consider to be the best?", "BobbyCrispyGuitar", DateTime.Now, DateTime.Now),
                new FeedDto(Guid.NewGuid(), "Vigilante Movie Suggestions?", "The below list are particular vigilante moves i absolutely love.Death Wish, Unbreakable,Death Sentence,Leon (the professional),Gran Torino,Drive,Kill Bill films(especially unbreakable, kill bill 2 , the professional)Can anyone give me any recommendations based on these vibes?Thanks, fellow movie aficionados.edited: Totally forgot about (Unforgiven 1992, which could top my entire list), Man on Fire , and Commando(1985- Pure nostalgia love and soundtrack as a kid in the 80s)r", "thorped077", DateTime.Now, DateTime.Now));
        }

        public DbSet<FeedDto> FeedsContext { get; set; }
    }
}
