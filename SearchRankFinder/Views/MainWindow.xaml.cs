using System.Threading.Tasks;
using System.Windows;
using SearchRankFinder.Core.Helpers;
using SearchRankFinder.Core.Search;
using SearchRankFinder.Models;

namespace SearchRankFinder.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISearcher searcher;
        private readonly MainWindowModel mainWindowModel = new MainWindowModel();

        public MainWindow(ISearcher searcher)
        {
            InitializeComponent();
            this.DataContext = mainWindowModel;
            this.searcher = searcher;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (mainWindowModel.Keywords.IsNullOrEmpty())
            {
                mainWindowModel.RankingResults = "Error: Enter valid keywords";
                return;
            }

            // This validation is a bit harsh however to reduce ambiguity of different variations of website urls
            // I've chosen to be strict rather than show results of potentially different websites.
            // 
            // For example technically the below are the same website but they result in different rankings
            // https://www.google.com or https://www.google.com.au
            if (!mainWindowModel.UrlToInspect.IsValidUrl())
            {
                mainWindowModel.RankingResults = "Error: Enter a valid url for inspection for example https://www.mywebsite.com";
                return;
            }

            mainWindowModel.RankingResults = await searcher.GetSearchRankingsAsync(mainWindowModel.Keywords, mainWindowModel.UrlToInspect);
        }
    }
}
