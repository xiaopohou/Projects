﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Configuration;
using VGtime.Models.Users;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class SearchUserCollection : IncrementalLoadingCollectionBase<UserBase>
    {
        private readonly Action<Exception> _onError;

        private readonly string _text;

        private readonly IUserService _userService;

        private readonly IVGtimeSettings _vgtimeSettings;

        public SearchUserCollection(string text, IUserService userService, IVGtimeSettings vgtimeSettings, Action<Exception> onError = null)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }
            if (vgtimeSettings == null)
            {
                throw new ArgumentNullException(nameof(vgtimeSettings));
            }

            _text = text;
            _userService = userService;
            _vgtimeSettings = vgtimeSettings;
            _onError = onError;
        }

        protected override async Task<uint> LoadMoreItemsAsync(uint count, CancellationToken cancellationToken)
        {
            if (IsLoading)
            {
                return 0;
            }

            IsLoading = true;
            try
            {
                var result = await _userService.SearchAsync(_text, _vgtimeSettings.UserInfo?.UserId, CurrentPage + 1);
                uint loadedCount = 0;
                if (result.Retcode == Constants.SuccessCode)
                {
                    CurrentPage++;

                    var data = result.Data.Data;
                    if (data.Length > 0)
                    {
                        foreach (var user in data)
                        {
                            if (this.All(temp => temp.UserId != user.UserId))
                            {
                                Add(user);
                                loadedCount++;
                            }
                        }
                    }
                    else
                    {
                        HasMoreItems = false;
                    }
                }

                return loadedCount;
            }
            catch (Exception ex)
            {
                _onError?.Invoke(ex);

                return 0;
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}