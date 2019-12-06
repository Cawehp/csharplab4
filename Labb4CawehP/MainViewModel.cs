using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Labb4CawehP
{
    public class MainViewModel : SimpleViewModel
    {

        private Country currentCountry;
        private List<Country> countries;
        private CountryRepository countryRepository = new CountryRepository();
        private int index;

        public ICommand PrevButton { get; private set; }
        public ICommand NextButton { get; private set; }
        

        public MainViewModel()
        {
            countries = countryRepository.GetCountries();
            currentCountry = countries.ElementAt(0);
            PrevClicked();
            NextClicked();
        }

        public Country CurrentCountry
        {
            get => currentCountry;
            set => SetPropertyValue(ref currentCountry, value);
        }
        
        private void PrevClicked()
        {
            PrevButton = new Command(() =>
            {
                index++;
                if (index > countries.Count() - 1)
                {
                    index = 0;
                }
                CurrentCountry = countries.ElementAt(index);

            });
        }

        private void NextClicked()
        {
            NextButton = new Command(() =>
            {
                index--;
                if (index < 0)
                {
                    index = countries.Count() - 1;
                }
                CurrentCountry = countries.ElementAt(index);

            });
        }


    }
}
