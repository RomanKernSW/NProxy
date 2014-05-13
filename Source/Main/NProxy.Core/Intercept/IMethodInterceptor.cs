﻿//
// Copyright © Martin Tamme
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace NProxy.Core.Intercept
{
    /// <summary>
    /// Defines a method interceptor.
    /// </summary>
    public interface IMethodInterceptor : IInterceptor
    {
        /// <summary>
        /// Implement this method to perform extra treatments before and after the invocation.
        /// Polite implementations would certainly like to invoke <see cref="IJoinpoint.Proceed()"/>.
        /// </summary>
        /// <param name="invocation">The method invocation joinpoint.</param>
        /// <returns>The result of the call to <see cref="IJoinpoint.Proceed()"/>,
        /// might be intercepted by the interceptor.</returns>
        object Invoke(IMethodInvocation invocation);
    }
}