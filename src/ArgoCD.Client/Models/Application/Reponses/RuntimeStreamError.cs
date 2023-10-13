namespace ArgoCD.Client.Models.Application.Reponses
{
    public class RuntimeStreamError
    {

        public ProtobufAny[] Details { get; set; }

        public int GrpcCode { get; set; }

        public int HttpCode { get; set; }


        public string HttpStatus { get; set; }


        public string Message { get; set; }
    }
}
