﻿using System;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private Post[] _headPosts;

        private bool _isLoadingHeadPosts;

        private RelayCommand<Post> _postClickCommand;

        private RelayCommand _refreshCommand;

        private RelayCommand _searchCommand;

        private RelayCommand<Post> _strategyPostClickCommand;

        public MainViewModel(IPostService postService, INavigationService navigationService, IAppToastService appToastService)
        {
            _postService = postService;
            _navigationService = navigationService;
            _appToastService = appToastService;

            ListPosts = new ListPostCollection(postService);
            NewsPosts = new TagPostCollection(postService, 1);
            EvalPosts = new TagPostCollection(postService, 4);
            VideoPosts = new TagPostCollection(postService, 2);
            StrategyPosts = new TagPostCollection(postService, 3);
            TopicPosts = new TagPostCollection(postService, 5);
            LoadHeadPostsAsync();
        }

        public TagPostCollection EvalPosts
        {
            get;
        }

        public Post[] HeadPosts
        {
            get
            {
                return _headPosts;
            }
            private set
            {
                Set(ref _headPosts, value);
            }
        }

        public bool IsLoadingHeadPosts
        {
            get
            {
                return _isLoadingHeadPosts;
            }
            private set
            {
                Set(ref _isLoadingHeadPosts, value);
            }
        }

        public ListPostCollection ListPosts
        {
            get;
        }

        public TagPostCollection NewsPosts
        {
            get;
        }

        public RelayCommand<Post> PostClickCommand
        {
            get
            {
                _postClickCommand = _postClickCommand ?? new RelayCommand<Post>(post =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.DetailViewKey, new DetailViewParameter(post.PostId, post.DetailType));
                });
                return _postClickCommand;
            }
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new RelayCommand(() =>
                {
                    throw new NotImplementedException();
                });
                return _refreshCommand;
            }
        }

        public RelayCommand SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.SearchViewKey);
                });
                return _searchCommand;
            }
        }

        public RelayCommand<Post> StrategyPostClickCommand
        {
            get
            {
                _strategyPostClickCommand = _strategyPostClickCommand ?? new RelayCommand<Post>(post =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.StrategyViewKey, post.PostId);
                });
                return _strategyPostClickCommand;
            }
        }

        public TagPostCollection StrategyPosts
        {
            get;
        }

        public TagPostCollection TopicPosts
        {
            get;
        }

        public TagPostCollection VideoPosts
        {
            get;
        }

        public async void LoadHeadPostsAsync()
        {
            if (IsLoadingHeadPosts)
            {
                return;
            }

            IsLoadingHeadPosts = true;
            try
            {
                var result = await _postService.GetHeadPicAsync();
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    HeadPosts = result.Data.Data;
                }
                else
                {
                    _appToastService.ShowError(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                _appToastService.ShowError(ex.Message);
            }
            finally
            {
                IsLoadingHeadPosts = false;
            }
        }
    }
}