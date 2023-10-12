namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ResourceDiff
    {

        public string Diff { get; set; }


        public string Group { get; set; }


        public bool Hook { get; set; }


        public string Kind { get; set; }


        public string LiveState { get; set; }


        public bool Modified { get; set; }


        public string Name { get; set; }


        public string VarNamespace { get; set; }


        public string NormalizedLiveState { get; set; }


        public string PredictedLiveState { get; set; }


        public string ResourceVersion { get; set; }


        public string TargetState { get; set; }
    }
}
