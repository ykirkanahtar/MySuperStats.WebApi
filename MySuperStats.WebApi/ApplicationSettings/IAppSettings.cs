﻿using CustomFramework.Authorization.Utils;

namespace MySuperStats.WebApi.ApplicationSettings
{
    public interface IAppSettings
    {
        int DefaultListCount { get; set; }
        int IterationCountForHashing { get; set; }
        Token Token { get; set; }
    }
}