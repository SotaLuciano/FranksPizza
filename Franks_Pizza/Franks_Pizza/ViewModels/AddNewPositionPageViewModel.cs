using Franks_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public class AddNewPositionPageViewModel
    {
        // UserBase connection
        private IUserBase _userBase;
        // Navigation
        private IPageService _pageService;

        public Position my_position { get; private set; }

        public event EventHandler<Position> PosAdded;

        // Commands
        public ICommand AddPizzaCommand { get; private set; }
        public ICommand AddSoupCommand { get; private set; }
        public ICommand AddDessertCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand AddCocaCommand { get; private set; }
        public ICommand AddSpriteCommand { get; private set; }
        public ICommand AddPepsiCommand { get; private set; }

        public AddNewPositionPageViewModel(IUserBase userBase, IPageService pageService)
        {
            _userBase = userBase;
            _pageService = pageService;

            AddPizzaCommand = new Command(async () => await Pizza());
            AddSoupCommand = new Command(async () => await Soup());
            AddDessertCommand = new Command(async () => await Dessert());
            ExitCommand = new Command(Exit);
            AddCocaCommand = new Command(async () => await Coca());
            AddSpriteCommand = new Command(async () => await Sprite());
            AddPepsiCommand = new Command(async () => await Pepsi());
        }

        private async Task Pizza()
        {
            // Creating list
            var _positions = new List<Position>
            {
                new Position{Name="Pizza", Description="Mexico", OnePrice=20, Count = 1 , Url="http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"},
                new Position{Name="Pizza", Description="Italiano", OnePrice=25, Count=1, Url= "http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"},
                new Position{Name="Pizza", Description="Neapolitan", OnePrice=115, Count=1, Url= "http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"},
                new Position{Name="Pizza", Description="Chicago", OnePrice=35, Count=1, Url= "http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"},
                new Position{Name="Pizza", Description="New York Style", OnePrice=18, Count=1, Url= "http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"},
                new Position{Name="Pizza", Description="Sicilian", OnePrice=34, Count=1, Url= "http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"},
                new Position{Name="Pizza", Description="Greek", OnePrice=41, Count=1, Url= "http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"},
                new Position{Name="Pizza", Description="California", OnePrice=10, Count=1, Url= "http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"},
                new Position{Name="Pizza", Description="Thin Crust", OnePrice=1, Count=1, Url= "http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"},
                new Position{Name="Pizza", Description="Alternative", OnePrice=33, Count=1, Url= "http://images.pizza33.ua/products_for_catalog/fKBxGDG2d4IxUR69a576Ct1QGwRa3xHP.jpg",
                Composition = "Italian flour or all-purpose flour, oz fresh yeast, water, salt, extra virgin olive oil, mozzarella cheese, basil, tomatoes"}
            };

            var viewModel = new PositionListPageViewModel(_userBase, _pageService, _positions);
            // If 'add to order' pressed -> invoke posAdded
            viewModel.PosAdded += (source, newPosition) =>
            {
                PosAdded?.Invoke(this, newPosition);
            };

            await _pageService.PushAsync(new PositionListPage(viewModel));
        }

        private async Task Soup()
        {
            // Creating list
            var _positions = new List<Position>
            {
                new Position{Name="Soup", Description="Mexico", OnePrice=22, Count = 1 , Url="http://cdn3.tmbi.com/toh/GoogleImages/Summer-Vegetable-Soup_exps18529_HWS133216C07_11_2bC_RMS.jpg",
                Composition = "Sturgeon, salmon, and freshwater crayfish, lemon juice is added to the soup"},
                new Position{Name="Soup", Description="Shchi", OnePrice=17, Count = 1 , Url="http://cdn3.tmbi.com/toh/GoogleImages/Summer-Vegetable-Soup_exps18529_HWS133216C07_11_2bC_RMS.jpg",
                Composition = "Sturgeon, salmon, and freshwater crayfish, lemon juice is added to the soup"},
                new Position{Name="Soup", Description="Solyanka", OnePrice=120, Count = 1 , Url="http://cdn3.tmbi.com/toh/GoogleImages/Summer-Vegetable-Soup_exps18529_HWS133216C07_11_2bC_RMS.jpg",
                Composition = "Sturgeon, salmon, and freshwater crayfish, lemon juice is added to the soup"},
                new Position{Name="Soup", Description="Svartsoppa", OnePrice=30, Count = 1 , Url="http://cdn3.tmbi.com/toh/GoogleImages/Summer-Vegetable-Soup_exps18529_HWS133216C07_11_2bC_RMS.jpg",
                Composition = "Sturgeon, salmon, and freshwater crayfish, lemon juice is added to the soup"},
                new Position{Name="Soup", Description="Tarator", OnePrice=40, Count = 1 , Url="http://cdn3.tmbi.com/toh/GoogleImages/Summer-Vegetable-Soup_exps18529_HWS133216C07_11_2bC_RMS.jpg",
                Composition = "Sturgeon, salmon, and freshwater crayfish, lemon juice is added to the soup"},
                new Position{Name="Soup", Description="Tarhana", OnePrice=63, Count = 1 , Url="http://cdn3.tmbi.com/toh/GoogleImages/Summer-Vegetable-Soup_exps18529_HWS133216C07_11_2bC_RMS.jpg",
                Composition = "Sturgeon, salmon, and freshwater crayfish, lemon juice is added to the soup"},
            };

            var viewModel = new PositionListPageViewModel(_userBase, _pageService, _positions);
            // If 'add to order' pressed -> invoke posAdded
            viewModel.PosAdded += (source, newPosition) =>
            {
                PosAdded?.Invoke(this, newPosition);
            };

            await _pageService.PushAsync(new PositionListPage(viewModel));
        }

        private async Task Dessert()
        {
            // Creating list
            var _positions = new List<Position>
            {
                new Position{Name="Dessert", Description="Charlotte", OnePrice=123, Count = 1 , Url="http://www.kraftrecipes.com/-/media/assets/2016-summer/berry-bliss-cake-106367-642x428.jpg",
                Composition = "Cheesecake (Vatrushka) is in the form of a dough ring and filled with quark or cottage cheese"},
                new Position{Name="Dessert", Description="Cheesecake", OnePrice=51, Count = 1 , Url="http://www.kraftrecipes.com/-/media/assets/2016-summer/berry-bliss-cake-106367-642x428.jpg",
                Composition = "Cheesecake (Vatrushka) is in the form of a dough ring and filled with quark or cottage cheese"},
                new Position{Name="Dessert", Description="Miguelitos", OnePrice=71, Count = 1 , Url="http://www.kraftrecipes.com/-/media/assets/2016-summer/berry-bliss-cake-106367-642x428.jpg",
                Composition = "Cheesecake (Vatrushka) is in the form of a dough ring and filled with quark or cottage cheese"},
                new Position{Name="Dessert", Description="Natillas", OnePrice=141, Count = 1 , Url="http://www.kraftrecipes.com/-/media/assets/2016-summer/berry-bliss-cake-106367-642x428.jpg",
                Composition = "Cheesecake (Vatrushka) is in the form of a dough ring and filled with quark or cottage cheese"},
                new Position{Name="Dessert", Description="Tiramisu", OnePrice=213, Count = 1 , Url="http://www.kraftrecipes.com/-/media/assets/2016-summer/berry-bliss-cake-106367-642x428.jpg",
                Composition = "Cheesecake (Vatrushka) is in the form of a dough ring and filled with quark or cottage cheese"},

            };

            var viewModel = new PositionListPageViewModel(_userBase, _pageService, _positions);
            // If 'add to order' pressed -> invoke posAdded
            viewModel.PosAdded += (source, newPosition) =>
            {
                PosAdded?.Invoke(this, newPosition);
            };

            await _pageService.PushAsync(new PositionListPage(viewModel));
        }

        private void Exit()
        {
            _pageService.PopAsync();
        }

        private async Task Coca()
        {
            // Choose cola size
            var choose = await _pageService.DisplayActionSheet("Choose your size!", "Cancel", null, "Coca 0.5 l. | 20$ ", "Coca 1 l. | 39$ ");

            if(choose == "Coca 0.5 l. | 20$ ")
            {
                my_position = new Position
                {
                    Name = "CocaCola",
                    Description = "0.5 l.",
                    OnePrice = 20,
                    Count = 1
                };

                // Add to order
                await _pageService.DisplayAlert("ORDER", my_position.Name + " added to your order!", "OK");
                PosAdded?.Invoke(this, my_position);
            }
            else if(choose == "Coca 1 l. | 39$ ")
            {
                my_position = new Position
                {
                    Name = "CocaCola",
                    Description = "1 l.",
                    OnePrice = 39,
                    Count = 1
                };
                // Add to order
                await _pageService.DisplayAlert("ORDER", my_position.Name + " added to your order!", "OK");
                PosAdded?.Invoke(this, my_position);
            }
        }

        private async Task Sprite()
        {
            // Choose sprite size
            var choose = await _pageService.DisplayActionSheet("Choose your size!", "Cancel", null, "Sprite 0.5 l. | 18$ ", "Sprite 1 l. | 37$ ");

            if (choose == "Sprite 0.5 l. | 18$ ")
            {
                my_position = new Position
                {
                    Name = "Sprite",
                    Description = "0.5 l.",
                    OnePrice = 18,
                    Count = 1
                };
                // Add to order
                await _pageService.DisplayAlert("ORDER", my_position.Name + " added to your order!", "OK");
                PosAdded?.Invoke(this, my_position);
            }
            else if (choose == "Sprite 1 l. | 37$ ")
            {
                my_position = new Position
                {
                    Name = "Sprite",
                    Description = "1 l.",
                    OnePrice = 37,
                    Count = 1
                };
                // Add to order
                await _pageService.DisplayAlert("ORDER", my_position.Name + " added to your order!", "OK");
                PosAdded?.Invoke(this, my_position);
            }
        }

        private async Task Pepsi()
        {
            // Choose pepsi size
            var choose = await _pageService.DisplayActionSheet("Choose your size!", "Cancel", null, "Pepsi 0.5 l. | 22$ ", "Pepsi 1 l. | 45$ ");

            if (choose == "Pepsi 0.5 l. | 22$ ")
            {
                my_position = new Position
                {
                    Name = "Pepsi",
                    Description = "0.5 l.",
                    OnePrice = 22,
                    Count = 1
                };
                // Add to order
                await _pageService.DisplayAlert("ORDER", my_position.Name + " added to your order!", "OK");
                PosAdded?.Invoke(this, my_position);
            }
            else if (choose == "Pepsi 1 l. | 45$ ")
            {
                my_position = new Position
                {
                    Name = "Pepsi",
                    Description = "1 l.",
                    OnePrice = 45,
                    Count = 1
                };
                await _pageService.DisplayAlert("ORDER", my_position.Name + " added to your order!", "OK");
                // Add to order
                PosAdded?.Invoke(this, my_position);
            }
        }

    }
}
