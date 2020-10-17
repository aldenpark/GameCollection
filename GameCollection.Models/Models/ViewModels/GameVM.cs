using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollection.Models.ViewModels
{
    public class GameVM
    {
        public Game Game { get; set; }
        public int[] SelectedGenres { get; set; }
        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}
