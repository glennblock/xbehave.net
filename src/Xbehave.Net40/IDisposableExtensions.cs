﻿// <copyright file="IDisposableExtensions.cs" company="Adam Ralph">
//  Copyright (c) Adam Ralph. All rights reserved.
// </copyright>

namespace Xbehave
{
    using System;
    using Xbehave.Sdk;

    /// <summary>
    /// <see cref="IDisposable"/> extensions.
    /// </summary>
    public static class IDisposableExtensions
    {
        /// <summary>
        /// Immediately registers the <see cref="IDisposable"/> object for disposal after all steps in the current scenario have been executed.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to be disposed.</param>
        /// <returns>The object.</returns>
        public static T Using<T>(this T obj) where T : IDisposable
        {
            CurrentScenario.AddDisposable(obj);
            return obj;
        }
    }
}