﻿using Beise.Models;
using Beise.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beise.ViewModels
{
    public  class ArticleViewModel: BaseViewModel
    {
        public ObservableCollection<ArticleListResult.Item> Items { get; private set; } 
        public Command LoadItemsCommand { get; }

        public ArticleViewModel()
        {
            Title = "文章列表";
            Items = new ObservableCollection<ArticleListResult.Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                ArticleService articleService = new ArticleService();
                
                var articles = articleService.GetArticles().Result.data.list;

                foreach(var article in articles)
                {
                    Items.Add(article);
                }
                OnPropertyChanged();


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}