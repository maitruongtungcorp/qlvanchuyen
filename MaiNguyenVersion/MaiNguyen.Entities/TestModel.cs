using System.Runtime.Serialization;

namespace MaiNguyen.Entities
{
    [DataContract]
    public class TestModel
    {
        [DataMember]
        public string Name { set; get; }
        [DataMember]
        public string Alias { set; get; }
    }
}
