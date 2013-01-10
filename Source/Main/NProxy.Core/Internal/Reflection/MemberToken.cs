﻿//
// NProxy is a library for the .NET framework to create lightweight dynamic proxies.
// Copyright © Martin Tamme
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
using System.Reflection;

namespace NProxy.Core.Internal.Reflection
{
    /// <summary>
    /// Represents a value which uniquely identifies a member.
    /// </summary>
    internal struct MemberToken : IEquatable<MemberToken>
    {
        /// <summary>
        /// The member module.
        /// </summary>
        private readonly Module _module;

        /// <summary>
        /// The member metadata token.
        /// </summary>
        private readonly int _metadataToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberToken"/> struct.
        /// </summary>
        /// <param name="memberInfo">The member information.</param>
        public MemberToken(MemberInfo memberInfo)
        {
            if (memberInfo == null)
                throw new ArgumentNullException("memberInfo");

            _module = memberInfo.Module;
            _metadataToken = memberInfo.MetadataToken;
        }

        #region IEquatable<MemberToken> Members

        /// <inheritdoc/>
        public bool Equals(MemberToken other)
        {
            if (!ReferenceEquals(other._module, _module))
                return false;

            return (other._metadataToken == _metadataToken);
        }

        #endregion

        #region Object Members

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return _metadataToken;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return (obj is MemberToken) && Equals((MemberToken) obj);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("[{0}]{1}", _module.Name, _metadataToken);
        }

        #endregion
    }
}
