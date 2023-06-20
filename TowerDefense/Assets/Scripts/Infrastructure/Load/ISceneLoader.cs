﻿using System;
using Infrastructure.Services;

namespace Infrastructure.Load
{
    internal interface ISceneLoader : IService
    {
        public void Load<T>(T t, Action onLoaded);
    }
}