using eserProje.Models;

namespace eserProje.ViewModel
{
    public class GiysiViewModel
    {
        public Cloth Cloth { get; set; }

        public IEnumerable<Cloth> Clothes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<MainCategory> MainCategories { get; set; }
    }
}
