// Copyright 2024 The argocd-dotnet-client Authors
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

#if COREFX
using System.Runtime.InteropServices;
#else
using System;
#endif

namespace ArgoCD.Client.Test.Utilities
{
    public static class FdOs
    {

#if COREFX
		public static bool IsWindows()
			=> RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

		public static bool IsOsx()
			=> RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

		public static bool IsLinux()
			=> RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
#else
        public static bool IsWindows()
          => Environment.OSVersion.Platform != PlatformID.MacOSX &&
             Environment.OSVersion.Platform != PlatformID.Unix;

        public static bool IsOsx()
          => Environment.OSVersion.Platform == PlatformID.MacOSX;

        public static bool IsLinux()
          => Environment.OSVersion.Platform == PlatformID.Unix;
#endif
    }
}
