using Absolute_Cinema.Models;

namespace Absolute_Cinema.ViewModels
{
    public class ViewMovies
    {
        public required IList<Movies> Movies { get; set; }
        public Movies? SelectedMovie { get; set; }
    }
}
