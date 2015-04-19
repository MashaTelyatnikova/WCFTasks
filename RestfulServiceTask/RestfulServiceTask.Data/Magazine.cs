using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestfulServiceTask.Data
{
    [DataContract]
    public class Magazine
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ReleaseMonth { get; set; }

        [DataMember]
        public IEnumerable<Article> Articles { get; set; } 
    }
}
