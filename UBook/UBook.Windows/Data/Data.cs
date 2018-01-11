using System.Collections.Generic;
using System.Xml.Serialization;
using UBook.Structure;

namespace UBook.Data
{
    [XmlRoot("Repository")]
    public class Data
    {
        private static Data mData = new Data();

        public Data()
        {
            mData = this;
            Objects = new List<User>();
        }

        [XmlIgnore]
        public List<User> Objects { get; private set; }

        public IEnumerable<User> Semantics
        {
            get { return Objects; }
        }

        public void Append(User aSemantic)
        {
            if (Objects.Contains(aSemantic)) return;
            Objects.Add(aSemantic);
        }

        public void Remove(User aSemantic)
        {
            if (!Objects.Contains(aSemantic)) return;
            Objects.Remove(aSemantic);
        }

    }

}
