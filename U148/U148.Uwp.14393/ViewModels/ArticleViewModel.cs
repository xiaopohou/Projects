﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using U148.Models;
using WinRTXamlToolkit.Tools;

namespace U148.Uwp.ViewModels
{
    public class ArticleViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ArticleViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IReadOnlyDictionary<ArticleCategory, IEnumerable<Article>> Categories
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}