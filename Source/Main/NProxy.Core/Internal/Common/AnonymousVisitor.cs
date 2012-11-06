﻿//
// NProxy is a library for the .NET framework to create lightweight dynamic proxies.
// Copyright © 2012 Martin Tamme
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see <http://www.gnu.org/licenses/>.
//
using System;

namespace NProxy.Core.Internal.Common
{
    /// <summary>
    /// Represents an anonymous visitor.
    /// </summary>
    /// <typeparam name="TElement">The element type.</typeparam>
    internal sealed class AnonymousVisitor<TElement> : IVisitor<TElement>
    {
        /// <summary>
        /// The visit action.
        /// </summary>
        private readonly Action<TElement> _visit;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousVisitor{TElement}"/> class.
        /// </summary>
        /// <param name="visit">The visit action.</param>
        public AnonymousVisitor(Action<TElement> visit)
        {
            if (visit == null)
                throw new ArgumentNullException("visit");

            _visit = visit;
        }

        #region IVisitor<TElement> Members

        /// <inheritdoc/>
        public void Visit(TElement element)
        {
            _visit(element);
        }

        #endregion
    }
}
