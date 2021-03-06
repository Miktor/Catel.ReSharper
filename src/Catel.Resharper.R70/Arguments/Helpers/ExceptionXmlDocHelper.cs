﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionXmlDocHelper.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments.Helpers
{
    using System;

    using Catel.ReSharper.Arguments.Patterns;

    /// <summary>
    /// The exception xml doc helper.
    /// </summary>
    public static class ExceptionXmlDocHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets implements interface exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get implements interface exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static string GetImplementsInterfaceExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.ImplementsInterface, declaredName);
        }

        /// <summary>
        /// The get is match exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared Name.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetIsMatchExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsMatch, declaredName);
        }

        /// <summary>
        /// Gets is maximun exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get is maximun exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static string GetIsMaximunExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsMaximum, declaredName);
        }

        /// <summary>
        /// Gets is minimal exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get is minimal exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static string GetIsMinimalExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsMinimal, declaredName);
        }

        /// <summary>
        /// The get is not match exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared Name.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetIsNotMatchExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsNotMatch, declaredName);
        }

        /// <summary>
        /// Gets is not null exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get is not null exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static string GetIsNotNullExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsNotNull, declaredName);
        }

        /// <summary>
        /// Gets is not null or empty array exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get is not null or empty array exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static string GetIsNotNullOrEmptyArrayExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsNotNullOrEmptyArray, declaredName);
        }

        /// <summary>
        /// Gets is not null or empty exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get is not null or empty exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static string GetIsNotNullOrEmptyExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsNotNullOrEmpty, declaredName);
        }

        /// <summary>
        /// Gets get is not null or whitespace exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get is not null or whitespace exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static string GetIsNotNullOrWhitespaceExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsNotNullOrWhitespace, declaredName);
        }

        /// <summary>
        /// Gets is not out of range exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get is not out of range exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static string GetIsNotOutOfRangeExceptionXmlDoc(string declaredName)
        {
            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsNotOutOfRange, declaredName);
        }

        /// <summary>
        /// Gets is of type exception xml doc.
        /// </summary>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get is of type exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static string GetIsOfTypeExceptionXmlDoc(string declaredName)
        {
            Argument.IsNotNullOrWhitespace(() => declaredName);

            return GetExceptionXmlDoc(ExceptionXmlDocPatterns.IsOfType, declaredName);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets exception xml doc.
        /// </summary>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <param name="declaredName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// The get exception xml doc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="pattern"/> is <c>null</c> or whitespace.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="declaredName"/> is <c>null</c> or whitespace.
        /// </exception>
        private static string GetExceptionXmlDoc(string pattern, string declaredName)
        {
            Argument.IsNotNullOrWhitespace(() => pattern);
            Argument.IsNotNullOrWhitespace(() => declaredName);

            return string.Format(pattern, declaredName);
        }

        #endregion
    }
}