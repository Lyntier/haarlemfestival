using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hf.Models;

namespace hf.Repository
{
    interface IArtistRepository
    {
        IEnumerable<Artist> GetArtistByName(string Name);
    }
}
