using Api_Implement.Model;
using Api_Implement.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Api_Implement.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand GetWordCommand { get; set; }
        IWordCategoryService wordCategoryApi = new WordCategoryService();

        public string Word { get; set; }

        public string Category { get; set; }

        Category WordCategories = new Category();

        public MainViewModel()
        {
            GetWordCommand = new Command(async () => await GetCategory());
        }

        public async Task GetCategory()
        {

            WordCategories = await wordCategoryApi.GetCategory(Word);

            Category = WordCategories.Categories[0];
            await App.Current.MainPage.DisplayAlert("Category", $"This word belongs to the category: {Category}", "Ok");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
