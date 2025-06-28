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

using ArgoCD.Client.Models.ApplicationSet.Reponses;
using ArgoCD.Client.Models.Project.Responses;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1Application
    {
 
        public V1ObjectMeta Metadata { get; set; }


        public V1alpha1Operation Operation { get; set; }


        public V1alpha1ApplicationSpec Spec { get; set; }


        public V1alpha1ApplicationStatus Status { get; set; }


    }
}
