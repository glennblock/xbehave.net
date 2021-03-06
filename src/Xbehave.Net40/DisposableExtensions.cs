﻿// <copyright file="DisposableExtensions.cs" company="xBehave.net contributors">
//  Copyright (c) xBehave.net contributors. All rights reserved.
// </copyright>

namespace Xbehave
{
    using System;
    using Xbehave.Sdk;

    /// <summary>
    /// <see cref="IDisposable"/> extensions.
    /// </summary>
    public static class DisposableExtensions
    {
        /// <summary>
        /// Immediately registers the <see cref="IDisposable"/> object for disposal after all steps in the current scenario have been executed.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to be disposed.</param>
        /// <returns>The object.</returns>
        public static T Using<T>(this T obj) where T : IDisposable
        {
            if (obj != null)
            {
                CurrentScenario.AddTeardown(() => obj.Dispose());
            }

            return obj;
        }
    }
}
