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
using System.Collections.Generic;
using NProxy.Core.Internal.Common;
using NProxy.Core.Internal.Descriptors;
using NProxy.Core.Test.Types;
using NUnit.Framework;

namespace NProxy.Core.Test.Internal.Descriptors
{
    [TestFixture]
    public sealed class InterfaceTypeDefinitionTestFixture
    {
        [Test]
        public void CreateReflectorTest()
        {
            // Arrange
            var proxyDescriptor = new InterfaceProxyDescriptor(typeof (IOne), new[] {typeof (ITwo), typeof (IOneTwo)});

            // Act
            var typeReflector = proxyDescriptor.CreateReflector();

            // Assert
            var interfaceTypes = new List<Type>();
            var visitor = Visitor.Create<Type>(interfaceTypes.Add);

            typeReflector.VisitInterfaces(visitor);

            Assert.That(interfaceTypes.Count, Is.EqualTo(4));
            Assert.That(interfaceTypes, Contains.Item(typeof (IBase)));
            Assert.That(interfaceTypes, Contains.Item(typeof (IOne)));
            Assert.That(interfaceTypes, Contains.Item(typeof (ITwo)));
            Assert.That(interfaceTypes, Contains.Item(typeof (IOneTwo)));
        }

        [Test]
        public void EqualsWithoutInterfacesTest()
        {
            // Arrange
            var firstProxyDescriptor = new InterfaceProxyDescriptor(typeof (IBase), Type.EmptyTypes);
            var secondProxyDescriptor = new InterfaceProxyDescriptor(typeof (IBase), Type.EmptyTypes);

            // Act
            var isEqual = firstProxyDescriptor.Equals(secondProxyDescriptor);

            // Assert
            Assert.That(isEqual, Is.True);
        }

        [Test]
        public void EqualsWithInterfacesTest()
        {
            // Arrange
            var firstProxyDescriptor = new InterfaceProxyDescriptor(typeof (IBase), new[] {typeof (IOne), typeof (ITwo)});
            var secondProxyDescriptor = new InterfaceProxyDescriptor(typeof (IBase), new[] {typeof (ITwo), typeof (IOne)});

            // Act
            var isEqual = firstProxyDescriptor.Equals(secondProxyDescriptor);

            // Assert
            Assert.That(isEqual, Is.True);
        }
    }
}