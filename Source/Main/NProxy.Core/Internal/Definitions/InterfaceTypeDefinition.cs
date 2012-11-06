//
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
using System.Reflection;
using NProxy.Core.Internal.Common;
using NProxy.Core.Internal.Reflection;

namespace NProxy.Core.Internal.Definitions
{
    /// <summary>
    /// Represents an interface type definition.
    /// </summary>
    internal sealed class InterfaceTypeDefinition : TypeDefinitionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterfaceTypeDefinition"/> class.
        /// </summary>
        /// <param name="declaringType">The declaring type.</param>
        public InterfaceTypeDefinition(Type declaringType)
            : base(declaringType)
        {
        }

        #region ITypeActivator Members

        /// <inheritdoc/>
        public override object CreateInstance(Type type, object[] arguments)
        {
            return Activator.CreateInstance(type, arguments);
        }

        #endregion

        #region ITypeDefinition Members

        /// <inheritdoc/>
        public override Type ParentType
        {
            get { return typeof (object); }
        }

        /// <inheritdoc/>
        public override void VisitInterfaces(IVisitor<Type> visitor)
        {
            // Visit additional interfaces.
            AdditionalInterfaceTypes.Visit(visitor);

            // Visit declaring interfaces.
            DeclaringInterfaceTypes.Visit(visitor);
        }

        /// <inheritdoc/>
        public override void VisitEvents(IVisitor<EventInfo> visitor)
        {
            // Visit additional interface events.
            AdditionalInterfaceTypes.Visit(t => t.VisitEvents(visitor));

            // Visit declaring interface events.
            DeclaringInterfaceTypes.Visit(t => t.VisitEvents(visitor));

            // Visit parent type events.
            ParentType.VisitEvents(visitor);
        }

        /// <inheritdoc/>
        public override void VisitProperties(IVisitor<PropertyInfo> visitor)
        {
            // Visit additional interface properties.
            AdditionalInterfaceTypes.Visit(t => t.VisitProperties(visitor));

            // Visit declaring interface properties.
            DeclaringInterfaceTypes.Visit(t => t.VisitProperties(visitor));

            // Visit parent type properties.
            ParentType.VisitProperties(visitor);
        }

        /// <inheritdoc/>
        public override void VisitMethods(IVisitor<MethodInfo> visitor)
        {
            if (visitor == null)
                throw new ArgumentNullException("visitor");

            var methodVisitor = visitor.Where(m => !m.IsSpecialName);

            // Visit additional interface methods.
            AdditionalInterfaceTypes.Visit(t => t.VisitMethods(methodVisitor));

            // Visit declaring interface methods.
            DeclaringInterfaceTypes.Visit(t => t.VisitMethods(methodVisitor));

            // Visit parent type methods.
            ParentType.VisitMethods(methodVisitor);
        }

        #endregion
    }
}
