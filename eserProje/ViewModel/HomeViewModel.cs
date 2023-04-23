using eserProje.Models;

namespace eserProje.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Cloth> Clothes { get; set; }

        public IEnumerable<MainCategory> MainCategories { get; set; }

    }
}
