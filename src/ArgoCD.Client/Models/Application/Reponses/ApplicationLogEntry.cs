namespace ArgoCD.Client.Models.Application.Reponses
{
    public class ApplicationLogEntry
    {

        public string Content { get; set; }


        public bool Last { get; set; }


        public string PodName { get; set; }


        public V1Time TimeStamp { get; set; }


        public string TimeStampStr { get; set; }
    }
}
