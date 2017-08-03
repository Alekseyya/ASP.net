using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.DataContracts.Service
{
    [DataContract]
    public class UserDataContract
    {
        [DataMember(IsRequired =true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true)]
        public string Password { get; set; }

        [DataMember(IsRequired = true)]
        public bool IsDeleted { get; set; }

        [DataMember(IsRequired = true)]
        public string Group { get; set; }

    }

    public class UserAdditionalDataContract
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
