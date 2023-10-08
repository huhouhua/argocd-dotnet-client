using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSpec
    {
        /// <summary>
        /// ApplicationDestination holds information about the application's destination
        /// </summary>
        public V1alpha1ApplicationDestination Destination { get; set; }


        /// <summary>
        /// IgnoreDifferences is a list of resources and their fields which should be ignored during comparison
        /// </summary>
        public V1alpha1ResourceIgnoreDifferences[] IgnoreDifferences { get; set; }

        /// <summary>
        /// Info contains a list of information (URLs, email addresses, and plain text) that relates to the application
        /// </summary>
        public V1alpha1Info[] Info { get; set; }

        /// <summary>
        /// Project is a reference to the project this application belongs to.
        /// The empty string means that application belongs to the 'default' project.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// RevisionHistoryLimit limits the number of items kept in the application's revision history, which is used for informational purposes
        /// as well as for rollbacks to previous versions.
        /// This should only be changed in exceptional circumstances.  Setting to zero will store no history. This will reduce storage used.
        /// Increasing will increase the space used to store the history, so we do not recommend increasing it. Default is 10.
        /// </summary>
        public string RevisionHistoryLimit { get; set; }

        /// <summary>
        /// ApplicationSource contains all required information about the source of an application
        /// </summary>
        public V1alpha1ApplicationSource Source { get; set; }


        /// <summary>
        /// Sources is a reference to the location of the application's manifests or chart
        /// </summary>
        public V1alpha1ApplicationSource[] SourceS { get; set; }

        /// <summary>
        /// SyncPolicy controls when a sync will be performed in response to updates in git
        /// </summary>
        public V1alpha1SyncPolicy SyncPolicy { get; set; }

    }
}
