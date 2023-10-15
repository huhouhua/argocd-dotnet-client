namespace ArgoCD.Client.Models.Application.Reponses
{
    public class ApplicationSyncWindow
    {

        public string Duration { get; set; }

        public string Kind { get; set; }


        public bool ManualSync { get; set; }


        public string Schedule { get; set; }
    }
}
