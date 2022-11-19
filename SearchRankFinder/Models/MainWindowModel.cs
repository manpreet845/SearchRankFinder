using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SearchRankFinder.Models
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private string keywords = string.Empty;
        private string urlToInspect = string.Empty;
        private string rankingResults = string.Empty;

        public string Keywords
        {
            get => keywords;
            set
            {
                if (value != keywords)
                {
                    keywords = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string UrlToInspect
        {
            get => urlToInspect;
            set
            {
                if (value != urlToInspect)
                {
                    urlToInspect = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string RankingResults
        {
            get => rankingResults;
            set
            {
                if (value != rankingResults)
                {
                    rankingResults = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
