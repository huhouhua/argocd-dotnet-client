namespace ArgoCD.Client.Models.GPKKey.Requests;

public sealed class GPGListQueryOptions
{
    public GPGListQueryOptions()
    {

    }

    /// <summary>
    /// The GPG key ID to query for.
    /// </summary>
    public string KeyID { get; set; }
}
