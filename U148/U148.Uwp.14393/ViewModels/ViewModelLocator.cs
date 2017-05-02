﻿using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using SoftwareKobo.Controls;
using SoftwareKobo.Services;
using U148.Configuration;
using U148.Services;
using U148.Uwp.Services;
using U148.Uwp.Views;

namespace U148.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public const string AboutViewKey = "About";

        public const string ArticleViewKey = "Article";

        public const string CommentViewKey = "Comment";

        public const string DetailViewKey = "Detail";

        public const string LoginViewKey = "Login";

        public const string MainViewKey = "Main";

        public const string RootViewKey = "Root";

        public const string SearchViewKey = "Search";

        public const string SettingViewKey = "Setting";

        static ViewModelLocator()
        {
            var serviceLocator = new UnityServiceLocator(ConfigureUnityContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public ArticleViewModel Article => ServiceLocator.Current.GetInstance<ArticleViewModel>();

        public CommentViewModel Comment => ServiceLocator.Current.GetInstance<CommentViewModel>();

        public DetailViewModel Detail => ServiceLocator.Current.GetInstance<DetailViewModel>();

        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public RootViewModel Root => ServiceLocator.Current.GetInstance<RootViewModel>();

        public SearchViewModel Search => ServiceLocator.Current.GetInstance<SearchViewModel>();

        public SettingViewModel Setting => ServiceLocator.Current.GetInstance<SettingViewModel>();

        private static IUnityContainer ConfigureUnityContainer()
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterInstance(CreateNavigationService());
            unityContainer.RegisterType<IArticleService, ArticleServiceWithCache>();
            unityContainer.RegisterType<IArticleServiceWithCache, ArticleServiceWithCache>();
            unityContainer.RegisterType<ICommentService, CommentService>();
            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IU148Settings, U148UwpSettings>();
            unityContainer.RegisterType<IAppToastService, AppToastService>();
            unityContainer.RegisterType<IU148ShareService, U148ShareService>();
            unityContainer.RegisterType<IStoreService, StoreService>();

            unityContainer.RegisterType<IU148Settings, U148UwpSettings>();

            unityContainer.RegisterInstance(DefaultImageLoader.Instance);

            unityContainer.RegisterType<RootViewModel>();
            unityContainer.RegisterType<MainViewModel>();
            unityContainer.RegisterType<ArticleViewModel>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<DetailViewModel>();
            unityContainer.RegisterType<CommentViewModel>();
            unityContainer.RegisterType<SearchViewModel>();
            unityContainer.RegisterType<SettingViewModel>();
            unityContainer.RegisterType<LoginViewModel>();
            unityContainer.RegisterType<AboutViewModel>();

            return unityContainer;
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new U148NavigationService();
            navigationService.Configure(ArticleViewKey, typeof(ArticleView), U148NavigationType.Master);
            navigationService.Configure(SearchViewKey, typeof(SearchView), U148NavigationType.Master);
            navigationService.Configure(DetailViewKey, typeof(DetailView), U148NavigationType.Detail);
            navigationService.Configure(CommentViewKey, typeof(CommentView), U148NavigationType.Detail);
            navigationService.Configure(AboutViewKey, typeof(AboutView), U148NavigationType.Detail);
            navigationService.Configure(SettingViewKey, typeof(SettingView), U148NavigationType.Detail);
            return navigationService;
        }
    }
}